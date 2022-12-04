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
-- Table structure for table `forms`
--

DROP TABLE IF EXISTS `forms`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `forms` (
  `FORM_CODE` varchar(128) NOT NULL,
  `teachers_CODE` int NOT NULL,
  `Q1_SCORE` int NOT NULL,
  `Q2_SCORE` int NOT NULL,
  `Q3_SCORE` int NOT NULL,
  `Q4_SCORE` int NOT NULL,
  `Q5_SCORE` int NOT NULL,
  `Q6_SCORE` int NOT NULL,
  `Q7_SCORE` int NOT NULL,
  `Q8_SCORE` int NOT NULL,
  `Q9_SCORE` int NOT NULL,
  `Q10_SCORE` int NOT NULL,
  UNIQUE KEY `FORM_CODE` (`FORM_CODE`),
  UNIQUE KEY `FORM_CODE_2` (`FORM_CODE`,`teachers_CODE`),
  KEY `teachers_CODE` (`teachers_CODE`),
  CONSTRAINT `forms_ibfk_1` FOREIGN KEY (`FORM_CODE`) REFERENCES `eval_status` (`FORM_CODE`) ON DELETE CASCADE,
  CONSTRAINT `forms_ibfk_2` FOREIGN KEY (`teachers_CODE`) REFERENCES `teachers` (`TEACHERS_CODE`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `forms`
--

LOCK TABLES `forms` WRITE;
/*!40000 ALTER TABLE `forms` DISABLE KEYS */;
INSERT INTO `forms` VALUES ('4e5b661f-b4ec-487d-89f5-357cd9fe5b46',2022432197,5,4,4,4,4,5,5,5,5,5),('7e239606-a93c-4191-86c7-403e384a37a9',2022123496,3,5,5,5,4,4,4,3,4,5);
/*!40000 ALTER TABLE `forms` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-12-04 21:58:57
