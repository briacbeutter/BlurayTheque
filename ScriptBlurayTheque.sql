-- MySQL dump 10.13  Distrib 5.7.36, for Linux (x86_64)
--
-- Host: localhost    Database: bluray
-- ------------------------------------------------------
-- Server version	5.7.36-0ubuntu0.18.04.1

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
-- Table structure for table `bluRayActeurs`
--

DROP TABLE IF EXISTS `bluRayActeurs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `bluRayActeurs` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `idBluray` int(11) NOT NULL,
  `idActeur` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_idActeur_joue` (`idActeur`),
  KEY `FK_idBluray_joue` (`idBluray`),
  CONSTRAINT `FK_idActeur_joue` FOREIGN KEY (`idActeur`) REFERENCES `personne` (`id`) ON DELETE CASCADE,
  CONSTRAINT `FK_idBluray_joue` FOREIGN KEY (`idBluray`) REFERENCES `bluray` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=38 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bluRayActeurs`
--

LOCK TABLES `bluRayActeurs` WRITE;
/*!40000 ALTER TABLE `bluRayActeurs` DISABLE KEYS */;
INSERT INTO `bluRayActeurs` VALUES (14,28,9),(15,28,10),(16,28,11),(23,31,14),(24,31,15),(25,31,16),(26,32,19),(27,32,20),(28,32,21),(29,33,29),(30,33,30),(31,33,31),(32,34,33),(33,34,34),(34,34,35),(35,36,39),(36,36,40),(37,36,41);
/*!40000 ALTER TABLE `bluRayActeurs` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `bluRayLangues`
--

DROP TABLE IF EXISTS `bluRayLangues`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `bluRayLangues` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `idBluray` int(11) NOT NULL,
  `idLangue` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_idBluRay_bluRayLangues` (`idBluray`),
  KEY `FK_idLangues_bluRayLangues` (`idLangue`),
  CONSTRAINT `FK_idBluRay_bluRayLangues` FOREIGN KEY (`idBluray`) REFERENCES `bluray` (`id`) ON DELETE CASCADE,
  CONSTRAINT `FK_idLangues_bluRayLangues` FOREIGN KEY (`idLangue`) REFERENCES `langues` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bluRayLangues`
--

LOCK TABLES `bluRayLangues` WRITE;
/*!40000 ALTER TABLE `bluRayLangues` DISABLE KEYS */;
/*!40000 ALTER TABLE `bluRayLangues` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `bluRayRealisateur`
--

DROP TABLE IF EXISTS `bluRayRealisateur`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `bluRayRealisateur` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `idBluray` int(11) NOT NULL,
  `idRealisateur` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_idBluRay_bluRayRealisateur` (`idBluray`),
  KEY `FK_idRealisateur_bluRayRealisateur` (`idRealisateur`),
  CONSTRAINT `FK_idBluRay_bluRayRealisateur` FOREIGN KEY (`idBluray`) REFERENCES `bluray` (`id`) ON DELETE CASCADE,
  CONSTRAINT `FK_idRealisateur_bluRayRealisateur` FOREIGN KEY (`idRealisateur`) REFERENCES `personne` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bluRayRealisateur`
--

LOCK TABLES `bluRayRealisateur` WRITE;
/*!40000 ALTER TABLE `bluRayRealisateur` DISABLE KEYS */;
INSERT INTO `bluRayRealisateur` VALUES (1,28,7),(4,31,12),(5,32,17),(6,33,27),(7,34,32),(8,36,36);
/*!40000 ALTER TABLE `bluRayRealisateur` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `bluRayScenariste`
--

DROP TABLE IF EXISTS `bluRayScenariste`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `bluRayScenariste` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `idBluray` int(11) NOT NULL,
  `idScenariste` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_idBluRay_bluRayScenariste` (`idBluray`),
  KEY `FK_idRealisateur_bluRayScenariste` (`idScenariste`),
  CONSTRAINT `FK_idBluRay_bluRayScenariste` FOREIGN KEY (`idBluray`) REFERENCES `bluray` (`id`) ON DELETE CASCADE,
  CONSTRAINT `FK_idRealisateur_bluRayScenariste` FOREIGN KEY (`idScenariste`) REFERENCES `personne` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bluRayScenariste`
--

LOCK TABLES `bluRayScenariste` WRITE;
/*!40000 ALTER TABLE `bluRayScenariste` DISABLE KEYS */;
INSERT INTO `bluRayScenariste` VALUES (5,28,7),(6,28,8),(7,31,12),(8,31,13),(9,32,17),(10,32,18),(11,33,27),(12,33,28),(13,34,32),(14,36,38),(15,36,37);
/*!40000 ALTER TABLE `bluRayScenariste` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `bluRaySsTitres`
--

DROP TABLE IF EXISTS `bluRaySsTitres`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `bluRaySsTitres` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `idBluray` int(11) NOT NULL,
  `idSsTitres` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_idActeur_ssTitres` (`idSsTitres`),
  KEY `FK_idBluray_ssTitres` (`idBluray`),
  CONSTRAINT `FK_idActeur_ssTitres` FOREIGN KEY (`idSsTitres`) REFERENCES `langues` (`id`) ON DELETE CASCADE,
  CONSTRAINT `FK_idBluray_ssTitres` FOREIGN KEY (`idBluray`) REFERENCES `bluray` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bluRaySsTitres`
--

LOCK TABLES `bluRaySsTitres` WRITE;
/*!40000 ALTER TABLE `bluRaySsTitres` DISABLE KEYS */;
/*!40000 ALTER TABLE `bluRaySsTitres` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `bluray`
--

DROP TABLE IF EXISTS `bluray`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `bluray` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `titre` varchar(100) NOT NULL,
  `duree` time DEFAULT NULL,
  `dateSortie` date NOT NULL,
  `version` varchar(100) NOT NULL,
  `emprunt` tinyint(1) NOT NULL DEFAULT '0',
  `proprietaire` int(11) NOT NULL DEFAULT '1',
  `disponible` tinyint(1) NOT NULL DEFAULT '0',
  `IdExterne` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_proprietaire_bluray` (`proprietaire`),
  CONSTRAINT `FK_proprietaire_bluray` FOREIGN KEY (`proprietaire`) REFERENCES `sourceEmprunt` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=37 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bluray`
--

LOCK TABLES `bluray` WRITE;
/*!40000 ALTER TABLE `bluray` DISABLE KEYS */;
INSERT INTO `bluray` VALUES (28,'Le Parrain','02:55:00','1972-10-18','VO',0,1,1,NULL),(31,'Inglorious Basterds','02:33:00','2009-08-19','VOSTFR',0,1,1,NULL),(32,'Spider-Man : No Way Home','02:29:00','2021-12-15','VOSTFR',0,1,1,NULL),(33,'Boîte Noire','02:10:00','2021-09-08','VO',0,1,1,NULL),(34,'Titanic','03:14:00','1998-01-07','VO',0,1,1,NULL),(36,'Skyfall','02:23:00','2012-10-26','VOST',0,1,1,NULL);
/*!40000 ALTER TABLE `bluray` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `langues`
--

DROP TABLE IF EXISTS `langues`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `langues` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `langue` varchar(100) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `langues`
--

LOCK TABLES `langues` WRITE;
/*!40000 ALTER TABLE `langues` DISABLE KEYS */;
INSERT INTO `langues` VALUES (1,'Français'),(2,'Anglais'),(3,'Italien'),(4,'Allemant'),(5,'Koréen');
/*!40000 ALTER TABLE `langues` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `personne`
--

DROP TABLE IF EXISTS `personne`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `personne` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nom` varchar(50) NOT NULL,
  `prenom` varchar(50) NOT NULL,
  `dateDeNaissance` date NOT NULL,
  `nationalite` varchar(100) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=42 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `personne`
--

LOCK TABLES `personne` WRITE;
/*!40000 ALTER TABLE `personne` DISABLE KEYS */;
INSERT INTO `personne` VALUES (1,'Goldin','Marilyn','1949-05-07','Américaine'),(2,'Garland','Robert','1937-05-01','Américaine'),(3,'Besson','Luc','1959-03-18','Française'),(4,'Barr','Jean-Marc','1960-09-27','Française, Américaine, Allemand\r\n'),(5,'Reno','Jean','1948-07-30','Française'),(6,'Arquette','Rosanna','1959-08-10','Américaine'),(7,'Ford Coppola','Francis','1939-04-07','Américaine'),(8,'Puzo','Mario','1920-10-15','Américaine'),(9,'Brando','Marlon','1924-04-03','Américaine'),(10,'Pacino','Al','1940-04-25','Américaine'),(11,'Caan','James','1939-03-26','Américaine'),(12,'Tarantino','Quentin','1963-03-27','Américaine'),(13,'Tykwer','Tom','1965-05-23','Allemande'),(14,'Pitt','Brad','1963-12-18','Américaine'),(15,'Laurent','Mélanie','1983-02-21','Française'),(16,'Waltz','Christoph','1956-10-04','Autrichienne'),(17,'McKenna','Chris','1969-12-03','Américaine'),(18,'Sommers','Erik','1976-12-16','Américaine'),(19,'Holland','Tom','1996-06-01','Britannique'),(20,'Maree','Zendaya','1996-09-01','Américaine'),(21,'Cumberbatch','Benedict','1976-07-19','Britannique'),(27,'Gozlan','Yann','1977-03-28','Française'),(28,'Moutaïrou','Simon','1983-05-12','Française'),(29,'Niney','Pierre','1989-03-13','Française'),(30,'De Laâge','Lou','1990-04-27','Française'),(31,'Dussollier','André','1946-02-17','Française'),(32,'Cameron','James','1954-08-16','Canadienne'),(33,'Di Caprio','Leonardo','1974-11-11','Américaine'),(34,'Winslet','Kate','1975-10-05','Britannique'),(35,'Zane','Billy','1966-02-24','Américaine'),(36,'Mendes','Sam','1965-08-01','Britannique'),(37,'Purvis','Neal','1961-09-09','Britannique'),(38,'Wade','Robert','1962-06-08','Américaine'),(39,'Craig','Daniel','1968-03-02','Britannique'),(40,'Dench','Judi','1934-12-09','Britannique'),(41,'Bardem','Javier','1969-03-01','Espagnole\r\n');
/*!40000 ALTER TABLE `personne` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sourceEmprunt`
--

DROP TABLE IF EXISTS `sourceEmprunt`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sourceEmprunt` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nom` varchar(100) NOT NULL,
  `baseUrl` varchar(200) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sourceEmprunt`
--

LOCK TABLES `sourceEmprunt` WRITE;
/*!40000 ALTER TABLE `sourceEmprunt` DISABLE KEYS */;
INSERT INTO `sourceEmprunt` VALUES (1,'nous','http://192.168.1.11:5001'),(3,'Timothée','http://172.23.5.133:5001');
/*!40000 ALTER TABLE `sourceEmprunt` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-01-21 20:00:00
