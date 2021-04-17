﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using src;

namespace src.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("EventMovie", b =>
                {
                    b.Property<int>("eventsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("moviesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("eventsId", "moviesId");

                    b.HasIndex("moviesId");

                    b.ToTable("EventMovie");
                });

            modelBuilder.Entity("MovieProduct", b =>
                {
                    b.Property<int>("moviesId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("productsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("moviesId", "productsId");

                    b.HasIndex("productsId");

                    b.ToTable("MovieProduct");
                });

            modelBuilder.Entity("src.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("additionalType")
                        .HasColumnType("TEXT");

                    b.Property<string>("email")
                        .HasColumnType("TEXT");

                    b.Property<string>("password")
                        .HasColumnType("TEXT");

                    b.Property<int>("userId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("email")
                        .IsUnique();

                    b.HasIndex("userId");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            additionalType = "local",
                            email = "admin01@example.com",
                            password = "admin01",
                            userId = 1
                        });
                });

            modelBuilder.Entity("src.Actor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("personId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("personId");

                    b.ToTable("Actors");
                });

            modelBuilder.Entity("src.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("MovieId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("about")
                        .HasColumnType("INTEGER");

                    b.Property<string>("commentText")
                        .HasColumnType("TEXT");

                    b.Property<int?>("creatorId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("dateCreated")
                        .HasColumnType("Date");

                    b.Property<DateTime>("dateModified")
                        .HasColumnType("Date");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.HasIndex("creatorId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("src.Director", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("personId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("personId");

                    b.ToTable("Directors");
                });

            modelBuilder.Entity("src.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("additionalType")
                        .HasColumnType("TEXT");

                    b.Property<string>("alternateName")
                        .HasColumnType("TEXT");

                    b.Property<string>("alternativeHeadline")
                        .HasColumnType("TEXT");

                    b.Property<string>("description")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("doorTime")
                        .HasColumnType("Date");

                    b.Property<double>("duration")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("endDate")
                        .HasColumnType("Date");

                    b.Property<string>("eventAttendanceMode")
                        .HasColumnType("TEXT");

                    b.Property<string>("eventStatus")
                        .HasColumnType("TEXT");

                    b.Property<string>("headline")
                        .HasColumnType("TEXT");

                    b.Property<string>("image")
                        .HasColumnType("TEXT");

                    b.Property<string>("inLanguage")
                        .HasColumnType("TEXT");

                    b.Property<bool>("isAccessibleForFree")
                        .HasColumnType("INTEGER");

                    b.Property<string>("location")
                        .HasColumnType("TEXT");

                    b.Property<int>("maximumAttendeeCapacity")
                        .HasColumnType("INTEGER");

                    b.Property<string>("organizer")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("startDate")
                        .HasColumnType("Date");

                    b.Property<string>("url")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("src.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("about")
                        .HasColumnType("TEXT");

                    b.Property<string>("abstractText")
                        .HasColumnType("TEXT");

                    b.Property<string>("additionalType")
                        .HasColumnType("TEXT");

                    b.Property<string>("alternativeHeadline")
                        .HasColumnType("TEXT");

                    b.Property<string>("contentRating")
                        .HasColumnType("TEXT");

                    b.Property<string>("copyrightHolder")
                        .HasColumnType("TEXT");

                    b.Property<string>("copyrightYear")
                        .HasColumnType("TEXT");

                    b.Property<string>("creator")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("dateCreated")
                        .HasColumnType("Date");

                    b.Property<DateTime>("dateModified")
                        .HasColumnType("Date");

                    b.Property<DateTime>("datePublished")
                        .HasColumnType("Date");

                    b.Property<double>("duration")
                        .HasColumnType("REAL");

                    b.Property<string>("headline")
                        .HasColumnType("TEXT");

                    b.Property<string>("inLanguage")
                        .HasColumnType("TEXT");

                    b.Property<bool>("isFamilyFriendly")
                        .HasColumnType("INTEGER");

                    b.Property<int>("isPartOf")
                        .HasColumnType("INTEGER");

                    b.Property<string>("locationCreated")
                        .HasColumnType("TEXT");

                    b.Property<string>("musicBy")
                        .HasColumnType("TEXT");

                    b.Property<int?>("parentMovieId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("producer")
                        .HasColumnType("TEXT");

                    b.Property<string>("trailerUrl")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("parentMovieId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("src.MovieList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("additionalType")
                        .HasColumnType("TEXT");

                    b.Property<string>("alternateName")
                        .HasColumnType("TEXT");

                    b.Property<string>("description")
                        .HasColumnType("TEXT");

                    b.Property<string>("headline")
                        .HasColumnType("TEXT");

                    b.Property<string>("itemListOrder")
                        .HasColumnType("TEXT");

                    b.Property<int>("numberOfItems")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ownerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ownerId");

                    b.ToTable("MovieLists");
                });

            modelBuilder.Entity("src.MovieListItem", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("MovieListId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("movieId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("order")
                        .HasColumnType("INTEGER");

                    b.Property<int>("parentListId")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("MovieListId");

                    b.HasIndex("movieId");

                    b.ToTable("MovieListItem");
                });

            modelBuilder.Entity("src.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("additionalName")
                        .HasColumnType("TEXT");

                    b.Property<string>("address")
                        .HasColumnType("TEXT");

                    b.Property<string>("alternateName")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("birthDate")
                        .HasColumnType("Date");

                    b.Property<string>("description")
                        .HasColumnType("TEXT");

                    b.Property<string>("familyName")
                        .HasColumnType("TEXT");

                    b.Property<string>("gender")
                        .HasColumnType("TEXT");

                    b.Property<string>("givenName")
                        .HasColumnType("TEXT");

                    b.Property<string>("image")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("People");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            birthDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            familyName = "Root",
                            givenName = "Admin"
                        });
                });

            modelBuilder.Entity("src.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("description")
                        .HasColumnType("TEXT");

                    b.Property<string>("headline")
                        .HasColumnType("TEXT");

                    b.Property<string>("image")
                        .HasColumnType("TEXT");

                    b.Property<string>("url")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("src.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("additionalType")
                        .HasColumnType("TEXT");

                    b.Property<string>("alternateName")
                        .HasColumnType("TEXT");

                    b.Property<int>("correctAnswer")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("dateCreated")
                        .HasColumnType("Date");

                    b.Property<DateTime>("dateModified")
                        .HasColumnType("Date");

                    b.Property<DateTime>("datePublished")
                        .HasColumnType("Date");

                    b.Property<string>("description")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("endDate")
                        .HasColumnType("Date");

                    b.Property<string>("optionSet")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("startDate")
                        .HasColumnType("Date");

                    b.Property<string>("title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("src.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("MovieId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("authorId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ratingValue")
                        .HasColumnType("INTEGER");

                    b.Property<int>("reviewAspect")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.HasIndex("authorId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("src.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("isActive")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("isAdmin")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("isDisabled")
                        .HasColumnType("INTEGER");

                    b.Property<int>("personId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("personId");

                    b.HasIndex("username")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            isActive = true,
                            isAdmin = true,
                            isDeleted = false,
                            isDisabled = false,
                            personId = 1,
                            username = "admin01"
                        });
                });

            modelBuilder.Entity("src.VoteAction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("QuestionId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("answer")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("dateCreated")
                        .HasColumnType("Date");

                    b.Property<DateTime>("dateModified")
                        .HasColumnType("Date");

                    b.Property<int>("userId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.HasIndex("userId");

                    b.ToTable("VoteActions");
                });

            modelBuilder.Entity("EventMovie", b =>
                {
                    b.HasOne("src.Event", null)
                        .WithMany()
                        .HasForeignKey("eventsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("src.Movie", null)
                        .WithMany()
                        .HasForeignKey("moviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MovieProduct", b =>
                {
                    b.HasOne("src.Movie", null)
                        .WithMany()
                        .HasForeignKey("moviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("src.Product", null)
                        .WithMany()
                        .HasForeignKey("productsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("src.Account", b =>
                {
                    b.HasOne("src.User", null)
                        .WithMany("accounts")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("src.Actor", b =>
                {
                    b.HasOne("src.Person", "person")
                        .WithMany()
                        .HasForeignKey("personId");

                    b.Navigation("person");
                });

            modelBuilder.Entity("src.Comment", b =>
                {
                    b.HasOne("src.Movie", null)
                        .WithMany("comments")
                        .HasForeignKey("MovieId");

                    b.HasOne("src.User", "creator")
                        .WithMany()
                        .HasForeignKey("creatorId");

                    b.Navigation("creator");
                });

            modelBuilder.Entity("src.Director", b =>
                {
                    b.HasOne("src.Person", "person")
                        .WithMany()
                        .HasForeignKey("personId");

                    b.Navigation("person");
                });

            modelBuilder.Entity("src.Movie", b =>
                {
                    b.HasOne("src.Movie", "parentMovie")
                        .WithMany()
                        .HasForeignKey("parentMovieId");

                    b.Navigation("parentMovie");
                });

            modelBuilder.Entity("src.MovieList", b =>
                {
                    b.HasOne("src.User", "owner")
                        .WithMany()
                        .HasForeignKey("ownerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("owner");
                });

            modelBuilder.Entity("src.MovieListItem", b =>
                {
                    b.HasOne("src.MovieList", null)
                        .WithMany("items")
                        .HasForeignKey("MovieListId");

                    b.HasOne("src.Movie", "item")
                        .WithMany()
                        .HasForeignKey("movieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("item");
                });

            modelBuilder.Entity("src.Rating", b =>
                {
                    b.HasOne("src.Movie", null)
                        .WithMany("ratings")
                        .HasForeignKey("MovieId");

                    b.HasOne("src.User", "author")
                        .WithMany()
                        .HasForeignKey("authorId");

                    b.Navigation("author");
                });

            modelBuilder.Entity("src.User", b =>
                {
                    b.HasOne("src.Person", "person")
                        .WithMany()
                        .HasForeignKey("personId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("person");
                });

            modelBuilder.Entity("src.VoteAction", b =>
                {
                    b.HasOne("src.Question", null)
                        .WithMany("answers")
                        .HasForeignKey("QuestionId");

                    b.HasOne("src.User", "agent")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("agent");
                });

            modelBuilder.Entity("src.Movie", b =>
                {
                    b.Navigation("comments");

                    b.Navigation("ratings");
                });

            modelBuilder.Entity("src.MovieList", b =>
                {
                    b.Navigation("items");
                });

            modelBuilder.Entity("src.Question", b =>
                {
                    b.Navigation("answers");
                });

            modelBuilder.Entity("src.User", b =>
                {
                    b.Navigation("accounts");
                });
#pragma warning restore 612, 618
        }
    }
}
