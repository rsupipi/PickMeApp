CREATE DATABASE  IF NOT EXISTS `pickme1` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `pickme1`;
-- MySQL dump 10.13  Distrib 5.6.17, for Win32 (x86)
--
-- Host: 127.0.0.1    Database: pickme1
-- ------------------------------------------------------
-- Server version	5.6.19

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `booking`
--

DROP TABLE IF EXISTS `booking`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `booking` (
  `booking_id` int(11) NOT NULL,
  `pickup_location` varchar(100) DEFAULT NULL,
  `drop_location` varchar(45) DEFAULT NULL,
  `status` varchar(45) DEFAULT NULL,
  `customer_id` int(11) DEFAULT NULL,
  `vhecle_number` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`booking_id`),
  KEY `vhecle_number_idx` (`vhecle_number`),
  CONSTRAINT `vhecle_number` FOREIGN KEY (`vhecle_number`) REFERENCES `vehicle` (`vhecle_number`) ON DELETE SET NULL ON UPDATE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `booking`
--

LOCK TABLES `booking` WRITE;
/*!40000 ALTER TABLE `booking` DISABLE KEYS */;
INSERT INTO `booking` VALUES (1,'05, Beach Road, Colombo 04','22, abc Road, Demata goda','waiting',NULL,'BDQ- 4525');
/*!40000 ALTER TABLE `booking` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `customer`
--

DROP TABLE IF EXISTS `customer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `customer` (
  `name` varchar(100) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `phone` int(11) NOT NULL,
  `password` varchar(100) DEFAULT NULL,
  `status` varchar(45) DEFAULT 'active',
  PRIMARY KEY (`phone`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customer`
--

LOCK TABLES `customer` WRITE;
/*!40000 ALTER TABLE `customer` DISABLE KEYS */;
INSERT INTO `customer` VALUES ('12345s','sss@gmail',0,'6512bd43d9caa6e02c990b0a82652dca','active'),('pipi','test@gmail.com',123,'202cb962ac59075b964b07152d234b70','active'),('sss','sss@gmail',75454,'6512bd43d9caa6e02c990b0a82652dca','active'),('Silva','test@gmail.com',123456,'202cb962ac59075b964b07152d234b70','active'),('test1','teset1@gmail.com',123456789,'202cb962ac59075b964b07152d234b70','active'),('Supipi','test@gmail.com',773627476,'123','active'),('ruchira','ruchira@gmail.com',773627479,'202cb962ac59075b964b07152d234b70','active'),('test','test@gmail.com',773658745,'202cb962ac59075b964b07152d234b70','active'),('Amal','test@gmail.com',775285476,'202cb962ac59075b964b07152d234b70','active'),('Kamal','test@gmail.com',775285478,'202cb962ac59075b964b07152d234b70','active');
/*!40000 ALTER TABLE `customer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `driver`
--

DROP TABLE IF EXISTS `driver`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `driver` (
  `NIC` varchar(45) NOT NULL DEFAULT '',
  `name` varchar(45) DEFAULT NULL,
  `title` varchar(10) DEFAULT NULL,
  `phoneNo` int(10) DEFAULT NULL,
  `Address` varchar(45) DEFAULT NULL,
  `license` varchar(45) DEFAULT NULL,
  `password` varchar(45) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`NIC`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `driver`
--

LOCK TABLES `driver` WRITE;
/*!40000 ALTER TABLE `driver` DISABLE KEYS */;
INSERT INTO `driver` VALUES ('111','Perera','Mr',775865856,'05, test, test','5584558','123','perera@gmail.com'),('123','555','Miss',71528695,'85, abc, Colombo','525454','202cb962ac59075b964b07152d234b70','acb@gmail.com'),('2222','Perera','Mr',775865856,'05, test, test','5584558','202cb962ac59075b964b07152d234b70','perera@gmail.com'),('3333','Perera','Mr',775865856,'05, test, test','5584558','202cb962ac59075b964b07152d234b70','perera@gmail.com'),('4444','Perera','Mr',775865856,'05, test, test','5584558','202cb962ac59075b964b07152d234b70','perera@gmail.com'),('72542545v','Amal','Mr',775847658,'08, test street , Test','5482545','202cb962ac59075b964b07152d234b70','amal@gmail.com');
/*!40000 ALTER TABLE `driver` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `vehicle`
--

DROP TABLE IF EXISTS `vehicle`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `vehicle` (
  `vhecle_number` varchar(45) NOT NULL DEFAULT '',
  `type` varchar(45) DEFAULT NULL,
  `brand` varchar(45) DEFAULT NULL,
  `model` varchar(45) DEFAULT NULL,
  `seets` int(11) DEFAULT NULL,
  `driver_id` varchar(45) DEFAULT NULL,
  `status` varchar(45) DEFAULT NULL,
  `details` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`vhecle_number`),
  KEY `FK_vehecle_1` (`driver_id`),
  CONSTRAINT `FK_vehecle_1` FOREIGN KEY (`driver_id`) REFERENCES `driver` (`NIC`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vehicle`
--

LOCK TABLES `vehicle` WRITE;
/*!40000 ALTER TABLE `vehicle` DISABLE KEYS */;
INSERT INTO `vehicle` VALUES ('BDQ- 4525','Car','Suzuki','Maruti',4,'72542545v','Available','This is vehicle test data');
/*!40000 ALTER TABLE `vehicle` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-08-16 16:45:40
