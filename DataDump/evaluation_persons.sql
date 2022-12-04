-- MySQL dump 10.13  Distrib 8.0.31, for Win64 (x86_64)
--
-- Host: localhost    Database: evaluation
-- ------------------------------------------------------
-- Server version	8.0.31

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `persons`
--

DROP TABLE IF EXISTS `persons`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `persons` (
  `PERSON_ID` int NOT NULL AUTO_INCREMENT,
  `FNAME` varchar(35) NOT NULL,
  `MNAME` varchar(25) DEFAULT NULL,
  `LNAME` varchar(30) NOT NULL,
  `DOB` date NOT NULL,
  `ROLE_CODE` int NOT NULL,
  `YR_START` int NOT NULL,
  `STATUS_CODE` int NOT NULL DEFAULT '1',
  PRIMARY KEY (`PERSON_ID`),
  UNIQUE KEY `FNAME` (`FNAME`,`MNAME`,`LNAME`),
  KEY `ROLE_CODE` (`ROLE_CODE`),
  KEY `STATUS_CODE` (`STATUS_CODE`),
  CONSTRAINT `persons_ibfk_1` FOREIGN KEY (`ROLE_CODE`) REFERENCES `person_roles` (`ROLE_CODE`),
  CONSTRAINT `persons_ibfk_2` FOREIGN KEY (`STATUS_CODE`) REFERENCES `person_status` (`STATUS_CODE`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `persons`
--

LOCK TABLES `persons` WRITE;
/*!40000 ALTER TABLE `persons` DISABLE KEYS */;
INSERT INTO `persons` VALUES (1,'Juan',NULL,'de la Cruz','2002-04-07',1,2022,1),(2,'Pedro','Agapito','Pinto','2001-11-29',1,2022,1),(3,'Liza','Handumon','Pineda','2002-06-18',1,2022,1),(4,'Mateo','Aquino','Santos','2002-09-10',1,2022,1),(5,'Jose','de Santos','Waldo','2001-09-11',1,2022,1),(6,'Mary Joy','Trinidad','de Santa','1964-04-11',2,1995,1),(7,'Carlos','Joaquim','Legaspi','1972-08-23',2,1997,1),(8,'Roberto',NULL,'Legarda','1969-05-02',2,2005,1),(9,'Walter',NULL,'Philips','1981-11-11',2,1992,1),(10,'Josephine',NULL,'Rizal','1988-02-09',2,2009,1),(11,'Mark','Bow','Dahlberg','2002-04-06',1,2002,1),(12,'Andrew','Mayn','Drotal','1988-06-04',3,2006,1);
/*!40000 ALTER TABLE `persons` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-12-04 21:58:56
