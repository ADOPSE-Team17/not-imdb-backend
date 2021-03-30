-- MariaDB dump 10.18  Distrib 10.4.16-MariaDB, for Win64 (AMD64)
--
-- Host: localhost    Database: imdb
-- ------------------------------------------------------
-- Server version	10.4.16-MariaDB

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `actor`
--

DROP TABLE IF EXISTS `actor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `actor` (
  `id` int(11) NOT NULL,
  `personId` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `person_id_const` (`personId`),
  CONSTRAINT `person_id_const` FOREIGN KEY (`personId`) REFERENCES `person` (`personId`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `actor`
--

LOCK TABLES `actor` WRITE;
/*!40000 ALTER TABLE `actor` DISABLE KEYS */;
/*!40000 ALTER TABLE `actor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `director`
--

DROP TABLE IF EXISTS `director`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `director` (
  `id` int(11) NOT NULL,
  `personId` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `person` (`personId`),
  CONSTRAINT `person` FOREIGN KEY (`personId`) REFERENCES `person` (`personId`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `director`
--

LOCK TABLES `director` WRITE;
/*!40000 ALTER TABLE `director` DISABLE KEYS */;
/*!40000 ALTER TABLE `director` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `directs_movie`
--

DROP TABLE IF EXISTS `directs_movie`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `directs_movie` (
  `directorId` int(11) DEFAULT NULL,
  `movieId` int(11) NOT NULL,
  KEY `dir_const` (`directorId`),
  KEY `movie_const` (`movieId`),
  CONSTRAINT `dir_const` FOREIGN KEY (`directorId`) REFERENCES `director` (`id`) ON DELETE SET NULL ON UPDATE CASCADE,
  CONSTRAINT `movie_const` FOREIGN KEY (`movieId`) REFERENCES `movie` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `directs_movie`
--

LOCK TABLES `directs_movie` WRITE;
/*!40000 ALTER TABLE `directs_movie` DISABLE KEYS */;
/*!40000 ALTER TABLE `directs_movie` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `event`
--

DROP TABLE IF EXISTS `event`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `event` (
  `id` int(11) NOT NULL,
  `additionalType` varchar(25) DEFAULT NULL,
  `alternateName` varchar(25) DEFAULT NULL,
  `headline` varchar(25) DEFAULT NULL,
  `alternativeHeadlne` varchar(25) DEFAULT NULL,
  `description` varchar(25) DEFAULT NULL,
  `image` varchar(25) DEFAULT NULL,
  `url` varchar(25) DEFAULT NULL,
  `organizer` varchar(25) DEFAULT NULL,
  `doorTime` date DEFAULT NULL,
  `startDate` date DEFAULT NULL,
  `endDate` date DEFAULT NULL,
  `duration` date DEFAULT NULL,
  `eventAttendanceMode` varchar(25) DEFAULT NULL,
  `eventStatus` varchar(25) DEFAULT NULL,
  `inLanguage` varchar(25) DEFAULT NULL,
  `isAccessibleForFree` varchar(25) DEFAULT NULL,
  `location` varchar(25) DEFAULT NULL,
  `maximumAttendanceCapacity` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `event`
--

LOCK TABLES `event` WRITE;
/*!40000 ALTER TABLE `event` DISABLE KEYS */;
/*!40000 ALTER TABLE `event` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `event_relation_to_movie`
--

DROP TABLE IF EXISTS `event_relation_to_movie`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `event_relation_to_movie` (
  `eventId` int(11) DEFAULT NULL,
  `movie` int(11) DEFAULT NULL,
  KEY `event_constraint` (`eventId`),
  KEY `movie_id_constraint` (`movie`),
  CONSTRAINT `event_constraint` FOREIGN KEY (`eventId`) REFERENCES `event` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `movie_id_constraint` FOREIGN KEY (`movie`) REFERENCES `movie` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `event_relation_to_movie`
--

LOCK TABLES `event_relation_to_movie` WRITE;
/*!40000 ALTER TABLE `event_relation_to_movie` DISABLE KEYS */;
/*!40000 ALTER TABLE `event_relation_to_movie` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `local_user_account`
--

DROP TABLE IF EXISTS `local_user_account`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `local_user_account` (
  `accountId` int(11) NOT NULL,
  `password` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`accountId`),
  CONSTRAINT `userAccId` FOREIGN KEY (`accountId`) REFERENCES `user_account` (`userAccId`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `local_user_account`
--

LOCK TABLES `local_user_account` WRITE;
/*!40000 ALTER TABLE `local_user_account` DISABLE KEYS */;
/*!40000 ALTER TABLE `local_user_account` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `movie`
--

DROP TABLE IF EXISTS `movie`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `movie` (
  `id` int(11) NOT NULL,
  `isPartOf` int(11) DEFAULT NULL,
  `headline` varchar(45) DEFAULT NULL,
  `alternativeHeadLine` varchar(45) DEFAULT NULL,
  `trailerURL` varchar(45) DEFAULT NULL,
  `about` text DEFAULT NULL,
  `abstract` text DEFAULT NULL,
  `musicBy` varchar(45) DEFAULT NULL,
  `producer` varchar(45) DEFAULT NULL,
  `duration` int(11) DEFAULT NULL,
  `datePublished` date DEFAULT NULL,
  `locationCreated` varchar(45) DEFAULT NULL,
  `contentRating` double DEFAULT NULL,
  `copyrightHolder` varchar(45) DEFAULT NULL,
  `copyrightYear` varchar(45) DEFAULT NULL,
  `creator` varchar(45) DEFAULT NULL,
  `inLanguage` varchar(45) DEFAULT NULL,
  `isFamilyFriendly` tinyint(4) DEFAULT NULL,
  `keywords` varchar(45) DEFAULT NULL,
  `dateCreated` date DEFAULT NULL,
  `dateModified` date DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `movie`
--

LOCK TABLES `movie` WRITE;
/*!40000 ALTER TABLE `movie` DISABLE KEYS */;
/*!40000 ALTER TABLE `movie` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER before_movie_delete
BEFORE DELETE
ON movie FOR EACH ROW
BEGIN
    INSERT INTO old_movie (id,
  isPartOf,
  headline,
  alternativeHeadLine,
  trailerURL,
  about,
  abstract,
  musicBy,
  producer,
  duration,
  datePublished,
  locationCreated,
  contentRating,
  copyrightHolder,
  copyrightYear,
  creator,
  inLanguage,
  isFamilyFriendly,
  keywords,
  dateCreated,
  dateModified)
    VALUES(OLD.id,
  OLD.isPartOf,
  OLD.headline,
  OLD.alternativeHeadLine,
  OLD.trailerURL,
  OLD.about,
  OLD.abstract,
  OLD.musicBy,
  OLD.producer,
  OLD.duration,
  OLD.datePublished,
  OLD.locationCreated,
  OLD.contentRating,
  OLD.copyrightHolder,
  OLD.copyrightYear,
  OLD.creator,
  OLD.inLanguage,
  OLD.isFamilyFriendly,
  OLD.keywords,
  OLD.dateCreated,
  OLD.dateModified);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `movie_list`
--

DROP TABLE IF EXISTS `movie_list`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `movie_list` (
  `id` int(11) NOT NULL,
  `owner` int(11) NOT NULL,
  `itemListOrder` varchar(25) DEFAULT NULL,
  `numberOfItems` int(11) NOT NULL,
  `alternateName` varchar(25) DEFAULT NULL,
  `description` text DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `user_constraint` (`owner`),
  CONSTRAINT `user_constraint` FOREIGN KEY (`owner`) REFERENCES `user` (`userId`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `movie_list`
--

LOCK TABLES `movie_list` WRITE;
/*!40000 ALTER TABLE `movie_list` DISABLE KEYS */;
/*!40000 ALTER TABLE `movie_list` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `movie_list_item`
--

DROP TABLE IF EXISTS `movie_list_item`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `movie_list_item` (
  `parentList` int(11) NOT NULL,
  `item` int(11) NOT NULL,
  KEY `movie_list_constraint` (`parentList`),
  KEY `mov_constraint` (`item`),
  CONSTRAINT `mov_constraint` FOREIGN KEY (`item`) REFERENCES `movie` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `movie_list_constraint` FOREIGN KEY (`parentList`) REFERENCES `movie_list` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `movie_list_item`
--

LOCK TABLES `movie_list_item` WRITE;
/*!40000 ALTER TABLE `movie_list_item` DISABLE KEYS */;
/*!40000 ALTER TABLE `movie_list_item` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `old_movie`
--

DROP TABLE IF EXISTS `old_movie`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `old_movie` (
  `id` int(11) NOT NULL,
  `isPartOf` int(11) DEFAULT NULL,
  `headline` varchar(45) DEFAULT NULL,
  `alternativeHeadLine` varchar(45) DEFAULT NULL,
  `trailerURL` varchar(45) DEFAULT NULL,
  `about` text DEFAULT NULL,
  `abstract` text DEFAULT NULL,
  `musicBy` varchar(45) DEFAULT NULL,
  `producer` varchar(45) DEFAULT NULL,
  `duration` int(11) DEFAULT NULL,
  `datePublished` date DEFAULT NULL,
  `locationCreated` varchar(45) DEFAULT NULL,
  `contentRating` double DEFAULT NULL,
  `copyrightHolder` varchar(45) DEFAULT NULL,
  `copyrightYear` varchar(45) DEFAULT NULL,
  `creator` varchar(45) DEFAULT NULL,
  `inLanguage` varchar(45) DEFAULT NULL,
  `isFamilyFriendly` tinyint(4) DEFAULT NULL,
  `keywords` varchar(45) DEFAULT NULL,
  `dateCreated` date DEFAULT NULL,
  `dateModified` date DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `old_movie`
--

LOCK TABLES `old_movie` WRITE;
/*!40000 ALTER TABLE `old_movie` DISABLE KEYS */;
/*!40000 ALTER TABLE `old_movie` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `participates_in_movie`
--

DROP TABLE IF EXISTS `participates_in_movie`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `participates_in_movie` (
  `actorId` int(11) NOT NULL,
  `movieId` int(11) NOT NULL,
  KEY `act_const` (`actorId`),
  KEY `mov_const` (`movieId`),
  CONSTRAINT `act_const` FOREIGN KEY (`actorId`) REFERENCES `actor` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `mov_const` FOREIGN KEY (`movieId`) REFERENCES `movie` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `participates_in_movie`
--

LOCK TABLES `participates_in_movie` WRITE;
/*!40000 ALTER TABLE `participates_in_movie` DISABLE KEYS */;
/*!40000 ALTER TABLE `participates_in_movie` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `person`
--

DROP TABLE IF EXISTS `person`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `person` (
  `personId` int(11) NOT NULL,
  `additionalName` varchar(45) DEFAULT NULL,
  `address` varchar(45) DEFAULT NULL,
  `birthDate` varchar(45) DEFAULT NULL,
  `familyName` varchar(45) DEFAULT NULL,
  `givenName` varchar(45) DEFAULT NULL,
  `gender` varchar(45) DEFAULT NULL,
  `description` text DEFAULT NULL,
  `image` varchar(45) DEFAULT NULL,
  `alternateName` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`personId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `person`
--

LOCK TABLES `person` WRITE;
/*!40000 ALTER TABLE `person` DISABLE KEYS */;
/*!40000 ALTER TABLE `person` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `product`
--

DROP TABLE IF EXISTS `product`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `product` (
  `id` int(11) NOT NULL,
  `headline` varchar(25) DEFAULT NULL,
  `description` varchar(25) DEFAULT NULL,
  `image` varchar(25) DEFAULT NULL,
  `url` varchar(25) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product`
--

LOCK TABLES `product` WRITE;
/*!40000 ALTER TABLE `product` DISABLE KEYS */;
/*!40000 ALTER TABLE `product` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `product_relation_to_movie`
--

DROP TABLE IF EXISTS `product_relation_to_movie`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `product_relation_to_movie` (
  `productId` int(11) DEFAULT NULL,
  `movieId` int(11) DEFAULT NULL,
  KEY `movie_id_const` (`movieId`),
  KEY `product_constraint` (`productId`),
  CONSTRAINT `movie_id_const` FOREIGN KEY (`movieId`) REFERENCES `movie` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `product_constraint` FOREIGN KEY (`productId`) REFERENCES `product` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product_relation_to_movie`
--

LOCK TABLES `product_relation_to_movie` WRITE;
/*!40000 ALTER TABLE `product_relation_to_movie` DISABLE KEYS */;
/*!40000 ALTER TABLE `product_relation_to_movie` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `question`
--

DROP TABLE IF EXISTS `question`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `question` (
  `id` int(11) NOT NULL,
  `additionalType` varchar(25) DEFAULT NULL,
  `alternateName` varchar(25) DEFAULT NULL,
  `title` varchar(25) DEFAULT NULL,
  `description` text DEFAULT NULL,
  `startDate` date DEFAULT NULL,
  `endDate` date DEFAULT NULL,
  `datePublished` date DEFAULT NULL,
  `optionSet` text DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `question`
--

LOCK TABLES `question` WRITE;
/*!40000 ALTER TABLE `question` DISABLE KEYS */;
/*!40000 ALTER TABLE `question` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `user` (
  `userId` int(11) NOT NULL,
  `accountId` int(11) DEFAULT NULL,
  `personId` int(11) DEFAULT NULL,
  `username` varchar(15) DEFAULT NULL,
  `isAdmin` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`userId`),
  KEY `account_id` (`accountId`),
  KEY `person_id` (`personId`),
  CONSTRAINT `account_id` FOREIGN KEY (`accountId`) REFERENCES `user_account` (`userAccId`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `person_id` FOREIGN KEY (`personId`) REFERENCES `person` (`personId`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user_account`
--

DROP TABLE IF EXISTS `user_account`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `user_account` (
  `userAccId` int(11) NOT NULL,
  `email` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`userAccId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_account`
--

LOCK TABLES `user_account` WRITE;
/*!40000 ALTER TABLE `user_account` DISABLE KEYS */;
/*!40000 ALTER TABLE `user_account` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user_comment`
--

DROP TABLE IF EXISTS `user_comment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `user_comment` (
  `id` int(11) NOT NULL,
  `creator` int(11) NOT NULL,
  `about` int(11) NOT NULL,
  `commentText` text NOT NULL,
  `createdAt` date NOT NULL,
  `updatedAt` date DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `movie_constraint` (`about`),
  CONSTRAINT `movie_constraint` FOREIGN KEY (`about`) REFERENCES `movie` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `user_const` FOREIGN KEY (`id`) REFERENCES `user` (`userId`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_comment`
--

LOCK TABLES `user_comment` WRITE;
/*!40000 ALTER TABLE `user_comment` DISABLE KEYS */;
/*!40000 ALTER TABLE `user_comment` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user_rating`
--

DROP TABLE IF EXISTS `user_rating`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `user_rating` (
  `authorId` int(11) NOT NULL,
  `reviewAspect` int(11) NOT NULL,
  `ratingValue` int(11) NOT NULL,
  KEY `auth_const` (`authorId`),
  KEY `review_const` (`reviewAspect`),
  CONSTRAINT `auth_const` FOREIGN KEY (`authorId`) REFERENCES `user` (`userId`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `review_const` FOREIGN KEY (`reviewAspect`) REFERENCES `movie` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_rating`
--

LOCK TABLES `user_rating` WRITE;
/*!40000 ALTER TABLE `user_rating` DISABLE KEYS */;
/*!40000 ALTER TABLE `user_rating` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `vote_action`
--

DROP TABLE IF EXISTS `vote_action`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `vote_action` (
  `agent` int(11) DEFAULT NULL,
  `target` int(11) DEFAULT NULL,
  `object` int(11) DEFAULT NULL,
  `dateCreated` date DEFAULT NULL,
  `dateModified` date DEFAULT NULL,
  KEY `agent_constraint` (`agent`),
  KEY `target_constraint` (`target`),
  CONSTRAINT `agent_constraint` FOREIGN KEY (`agent`) REFERENCES `user` (`userId`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `target_constraint` FOREIGN KEY (`target`) REFERENCES `question` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vote_action`
--

LOCK TABLES `vote_action` WRITE;
/*!40000 ALTER TABLE `vote_action` DISABLE KEYS */;
/*!40000 ALTER TABLE `vote_action` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'imdb'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-03-30 15:00:26
