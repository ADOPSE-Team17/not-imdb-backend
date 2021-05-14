using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;

namespace src.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class EventsController : ControllerBase
  {

    private readonly ILogger<EventsController> _logger;
    private readonly ApplicationDbContext _context;

    public EventsController(
      ILogger<EventsController> logger,
      ApplicationDbContext context
    )
    {
      _logger = logger;
      _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Event>>> Get()
    {
        var allevents = await this._context.Events
            .Include("movies")
            .ToArrayAsync();
        return allevents;
    }

    [HttpGet("free")]
    public async Task<ActionResult<IEnumerable<Event>>> GetFreeEvents()
    {
        var freeEvents = await this._context.Events
            .Include("movies")
            .Where(m => m.isAccessibleForFree == true)
            .ToArrayAsync();
        return freeEvents;
    }

    [HttpGet("nearevents/{location}")]
    public async Task<ActionResult<IEnumerable<Event>>> GetNearEvents(string location)
    {
        var nearEvents = await this._context.Events
            .Include("movies")
            .Where(m => m.location == location)
            .ToArrayAsync();
        return nearEvents;
    }

    [HttpGet("joinEvent/{id}")]
    public async Task<ActionResult<Event>> JoinEvent(int id)
    {
        var join = await this._context.Events
            .Include("movies")
            .Where(e => e.Id == id)
            .FirstOrDefaultAsync();
        
        if(join is null)
        {
            return NotFound( new {
                message = "event not found"
            });
        }

        if(join.maximumAttendeeCapacity == 0)
        {
            return NotFound( new {
                message = "event is full"
            });
        }

        join.maximumAttendeeCapacity = join.maximumAttendeeCapacity - 1;
        await _context.SaveChangesAsync();
        Console.WriteLine("The maximumAttendeeCapacity of the event with id = ", join.Id, "is modified");

        return join;
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Event>> Getevent(int id)
    {
      var anEvent = await this._context.Events
        .Include("movies")
        .Where(m => m.Id == id)
        .FirstOrDefaultAsync();

      if (anEvent is null)
      {
        return NotFound();
      }

      return anEvent;
    }

    [HttpPost]
    public async Task<ActionResult<Event>> CreateEvent(Event anEvent)
    {
        this._context.Events.Add(anEvent);
        await _context.SaveChangesAsync();
        return anEvent;
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Event>> UpdateEvent(int id, Event anEvent) 
    {
        if (id != anEvent.Id)
        {
            return BadRequest();
        }

        _context.Entry(anEvent).State = EntityState.Modified;
        var localevent = await this._context.Events.Where(m => m.Id == id).FirstOrDefaultAsync();

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (anEvent is null)
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        return anEvent;
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Event>> DeleteEvent(int id)
    {
        var anEvent = await _context.Events.FindAsync(id);
        if (anEvent == null)
        {
            return NotFound();
        }

        _context.Events.Remove(anEvent);
        await _context.SaveChangesAsync();

        return anEvent;
    }
  }
}