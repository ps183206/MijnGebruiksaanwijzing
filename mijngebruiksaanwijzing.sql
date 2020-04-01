-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Gegenereerd op: 25 mrt 2020 om 13:53
-- Serverversie: 5.7.19
-- PHP-versie: 7.3.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `mijngebruiksaanwijzing`
--

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `cards`
--

DROP TABLE IF EXISTS `cards`;
CREATE TABLE IF NOT EXISTS `cards` (
  `CardID` int(11) NOT NULL AUTO_INCREMENT,
  `CardDesc` varchar(100) NOT NULL,
  `CardColor` varchar(20) NOT NULL,
  `CardType` int(11) NOT NULL,
  PRIMARY KEY (`CardID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `cardtype`
--

DROP TABLE IF EXISTS `cardtype`;
CREATE TABLE IF NOT EXISTS `cardtype` (
  `TypeID` int(11) NOT NULL,
  `Type` varchar(20) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Gegevens worden geëxporteerd voor tabel `cardtype`
--

INSERT INTO `cardtype` (`TypeID`, `Type`) VALUES
(0, 'School'),
(1, 'Intern');

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `results`
--

DROP TABLE IF EXISTS `results`;
CREATE TABLE IF NOT EXISTS `results` (
  `UserID` int(11) NOT NULL,
  `RedCard` int(11) NOT NULL,
  `Comment` varchar(100) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `resultsgreen`
--

DROP TABLE IF EXISTS `resultsgreen`;
CREATE TABLE IF NOT EXISTS `resultsgreen` (
  `UserID` int(11) NOT NULL,
  `GreenCard` int(11) NOT NULL,
  `RedCard` int(11) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `resultsyellow`
--

DROP TABLE IF EXISTS `resultsyellow`;
CREATE TABLE IF NOT EXISTS `resultsyellow` (
  `UserID` int(11) NOT NULL,
  `YellowCard` int(11) NOT NULL,
  `RedCard` int(11) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `roles`
--

DROP TABLE IF EXISTS `roles`;
CREATE TABLE IF NOT EXISTS `roles` (
  `RoleID` int(11) NOT NULL,
  `Role` varchar(30) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Gegevens worden geëxporteerd voor tabel `roles`
--

INSERT INTO `roles` (`RoleID`, `Role`) VALUES
(1, 'Student'),
(0, 'Docent');

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `users`
--

DROP TABLE IF EXISTS `users`;
CREATE TABLE IF NOT EXISTS `users` (
  `UserID` int(11) NOT NULL AUTO_INCREMENT,
  `FirstName` varchar(30) NOT NULL,
  `LastName` varchar(30) NOT NULL,
  `UserName` varchar(30) NOT NULL,
  `Password` varchar(30) NOT NULL,
  `Role` int(11) NOT NULL,
  PRIMARY KEY (`UserID`),
  UNIQUE KEY `UserName` (`UserName`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
