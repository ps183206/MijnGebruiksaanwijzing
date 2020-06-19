-- phpMyAdmin SQL Dump
-- version 4.9.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Gegenereerd op: 19 jun 2020 om 09:37
-- Serverversie: 10.4.10-MariaDB
-- PHP-versie: 7.3.12

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
  `CardDesc` varchar(200) NOT NULL,
  `CardColor` varchar(10) NOT NULL,
  `CardType` int(1) NOT NULL,
  PRIMARY KEY (`CardID`)
) ENGINE=MyISAM AUTO_INCREMENT=212 DEFAULT CHARSET=latin1;

--
-- Gegevens worden geëxporteerd voor tabel `cards`
--

INSERT INTO `cards` (`CardID`, `CardDesc`, `CardColor`, `CardType`) VALUES
(1, 'Ik vind het lastig om een vraag te stellen in de klas', 'Red', 0),
(2, 'Ik heb moeite met het begrijpen van gezichtsuitdrukkingen (boos, blij, verdrietig)', 'Red', 0),
(3, 'Ik heb weinig contact met klasgenoten ', 'Red', 0),
(4, 'Ik laat niet merken als het niet goed met me gaat ', 'Red', 0),
(5, 'Ik heb soms last van paniekaanvallen ', 'Red', 0),
(6, 'Ik heb moeite met grapjes, plagerijtjes of spreekwoorden', 'Red', 0),
(7, 'Ik weet niet waar ik moet gaan zitten in de pauze', 'Red', 0),
(8, 'Ik vind het lastig om op tijd te komen', 'Red', 0),
(9, 'Ik vind het moeilijk om hulp te vragen', 'Red', 0),
(10, 'Mijn stemming kan erg wisselen', 'Red', 0),
(11, 'Als iemand iets uitlegt begrijp ik het soms niet helemaal', 'Red', 0),
(12, 'Ik vind het lastig om lang naar iemand te luisteren', 'Red', 0),
(13, 'Ik raak snel het overzicht kwijt bij huiswerk', 'Red', 0),
(14, 'Ik kan niet goed reageren op kritiek', 'Red', 0),
(15, 'Ik ben vaak stil in de klas', 'Red', 0),
(16, 'Ik ben vaak te druk in de klas ', 'Red', 0),
(17, 'Ik ben onzeker', 'Red', 0),
(18, 'Ik laat niet merken als ik boos ben', 'Red', 0),
(19, 'Bij te weinig structuur word ik onzeker', 'Red', 0),
(20, 'Ik heb moeite met plannen', 'Red', 0),
(21, 'Ik ben snel afgeleid', 'Red', 0),
(22, 'Spanning kan bij mij erg oplopen door studiedruk', 'Red', 0),
(23, 'Ik stel te hoge eisen aan mezelf ', 'Red', 0),
(24, 'Ik voel me continu gespannen ', 'Red', 0),
(25, 'Ik reageer impulsief als er iets vervelends gebeurt', 'Red', 0),
(26, 'Ik voel me vaak onbegrepen', 'Red', 0),
(27, 'Ik heb vaak gebrek aan energie ', 'Red', 0),
(28, 'Ik heb moeite met slapen ', 'Red', 0),
(29, 'Ik maak me veel zorgen', 'Red', 0),
(30, 'Ik twijfel vaak', 'Red', 0),
(31, 'Als er iets wordt uitgelegd kan ik niet alles onthouden', 'Red', 0),
(32, 'Ik vind het moeilijk om met iemand samen te werken', 'Red', 0),
(33, 'Ik word snel boos', 'Red', 0),
(34, 'Ik heb soms te veel energie', 'Red', 0),
(35, 'Ik heb moeite om aan een opdracht te beginnen', 'Red', 0),
(36, 'Ik eet onregelmatig', 'Red', 0),
(37, 'Ik vind dat ik veel drink/blow', 'Red', 0),
(38, 'Ik word soms gepest', 'Red', 0),
(39, 'Ik game veel', 'Red', 0),
(40, 'Ik vind het niet prettig als mensen me aanraken', 'Red', 0),
(41, 'Ik vergeet mijn spullen vaak mee te nemen', 'Red', 0),
(42, 'Ik weet niet goed wat ik moet doen als ik vastloop bij het maken van huiswerk', 'Red', 0),
(43, 'Ik stel mijn werk vaak uit', 'Red', 0),
(44, 'Ik twijfel of ik de juiste studiekeuze heb gemaakt', 'Red', 0),
(45, 'Ik ben erg beïnvloedbaar door mijn omgeving', 'Red', 0),
(46, 'Ik weet vaak niet wat ik moet leren/maken', 'Red', 0),
(47, 'Ik heb vaak een vol hoofd', 'Red', 0),
(48, 'Ik ben telkens met veel verschillende taken tegelijkertijd bezig', 'Red', 0),
(49, 'Als ik stress heb krijg ik allerlei lichamelijke klachten', 'Red', 0),
(50, 'Ik vind het soms moeilijk om me in te leven in een ander', 'Red', 0),
(51, 'Ik gebruik een agenda', 'Yellow', 0),
(52, 'Ik zet muziek op', 'Yellow', 0),
(53, 'Ik bespreek dit met mijn mentor en we kijken samen met wie ik het beste een team kan vormen ', 'Yellow', 0),
(54, 'Ik vertel aan mijn medestudenten dat ik dit moeilijk vind, eventueel samen met mijn mentor ', 'Yellow', 0),
(55, 'Ik zoek in het lokaal de plek waar ik het minst wordt afgeleid', 'Yellow', 0),
(56, 'Ik schrijf op waar ik goed in ben', 'Yellow', 0),
(57, 'Ik vraag aan mijn ouders of andere huisgenoten of ze samen met mij de tijd in de gaten houden ‘s ochtends', 'Yellow', 0),
(58, 'Ik houd mijn mappen goed bij met alles achter een eigen tabblad ', 'Yellow', 0),
(59, 'Ik bespreek hoe ik het beste mijn pauze kan invullen; bijvoorbeeld even naar buiten of rustig alleen zitten met een boek', 'Yellow', 0),
(60, 'Ik leg alle spullen voor school op een vaste plaats', 'Yellow', 0),
(61, 'Ik pauzeer (in overleg met de docent) af en toe een keertje extra', 'Yellow', 0),
(62, 'Ik schrijf mijn gevoelens op', 'Yellow', 0),
(63, 'Bij het huiswerk maken leg ik mijn telefoon weg', 'Yellow', 0),
(64, 'Op school zet ik mijn telefoon uit', 'Yellow', 0),
(65, 'Ik schrijf mijn vragen op en stel ze op een goed moment', 'Yellow', 0),
(66, 'Ik spreek af dat iemand regelmatig aan me vraagt hoe ik me voel', 'Yellow', 0),
(67, 'Ik spreek af dat ik dan naar iemand toe kan, of even naar buiten kan', 'Yellow', 0),
(68, 'k vertel dat het mij helpt als er veel afwisseling is in de les', 'Yellow', 0),
(69, 'Ik zeg tegen mezelf dat het slim is om te vragen', 'Yellow', 0),
(70, 'Ik zoek een maatje op school', 'Yellow', 0),
(71, 'Ik vraag hulp bij het leren geven en krijgen van kritiek', 'Yellow', 0),
(72, 'Inzicht in mijn belemmering helpt mij', 'Yellow', 0),
(73, 'Ik spreek af naar wie ik toe kan lopen als dit gebeurt', 'Yellow', 0),
(74, 'Ik vraag om meer uitleg en maak aantekeningen, die laat ik zien en vraag of het klopt', 'Yellow', 0),
(75, 'Ik herhaal wat ik denk dat de ander gezegd heeft', 'Yellow', 0),
(76, 'Ik maak een lijstje met voor- en nadelen', 'Yellow', 0),
(77, 'Ontspannings- / mindfullnessoefeningen', 'Yellow', 0),
(78, 'Ik schrijf het probleem op', 'Yellow', 0),
(79, 'Ik vraag om een rustige studieruimte', 'Yellow', 0),
(80, 'Ik ruim de kamer waarin ik huiswerk maak goed op', 'Yellow', 0),
(81, 'Ik gebruik een boksbal', 'Yellow', 0),
(82, 'Ik neem regelmatig pauzes bij het studeren', 'Yellow', 0),
(83, 'Ik gebruik mijn medicijnen', 'Yellow', 0),
(84, 'Ik beweeg regelmatig en ga regelmatig sporten', 'Yellow', 0),
(85, 'Ik bespreek mijn gevoelens met iemand', 'Yellow', 0),
(86, 'Ik ga op tijd naar bed en eet regelmatig en gezond', 'Yellow', 0),
(87, 'In een studiegroepje maak ik vaste afspraken en leg uit dat dit heel belangrijk voor me is', 'Yellow', 0),
(88, 'Ik zorg voor een goede dagplanning', 'Yellow', 0),
(89, 'Ik zoek een rustige ruimte met weinig prikkels', 'Yellow', 0),
(90, 'Ik loop zo nu en dan een rondje tussendoor', 'Yellow', 0),
(91, 'Ik maak een vaste weekindeling', 'Yellow', 0),
(92, 'Ik vraag aan de docent of hij het huiswerk op het bord wil schrijven', 'Yellow', 0),
(93, 'Ik bespreek met mijn mentor of docent wat de minimumeisen zijn', 'Yellow', 0),
(94, 'Ik spreek af dat ik zo nu en dan mijn oortjes op mag zetten in de klas', 'Yellow', 0),
(95, 'Ik markeer belangrijke informatie', 'Yellow', 0),
(96, 'Ik maak een samenvatting van de leerstof', 'Yellow', 0),
(97, 'Ik schrijf mijn vragen over het huiswerk op en stel ze op school', 'Yellow', 0),
(98, 'Ik bespreek mijn huiswerkgedrag en bedenk dingen die me kunnen helpen', 'Yellow', 0),
(99, 'Ik maak eerst een taak af voordat ik aan de volgende taak begi', 'Yellow', 0),
(100, 'Vriend of vriendin', 'Blue', 0),
(101, 'Studiemaatje', 'Blue', 0),
(102, 'Medestudent', 'Blue', 0),
(103, 'Studentenbegeleider of zorgcoach', 'Blue', 0),
(104, 'Vader of moeder', 'Blue', 0),
(105, 'Mentor', 'Blue', 0),
(106, 'Werkbegeleider', 'Blue', 0),
(107, 'Stagebegeleider', 'Blue', 0),
(108, 'Ikzelf', 'Blue', 0),
(109, 'Docent', 'Blue', 0),
(110, 'Adviseur passend onderwijs', 'Blue', 0),
(111, 'Psycholoog', 'Blue', 0),
(112, 'Thuisbegeleider', 'Blue', 0),
(113, 'Ik vind het lastig om  een vraag te stellen', 'Red', 1),
(114, 'Ik heb moeite met het begrijpen van gezichtsuitdrukkingen', 'Red', 1),
(115, 'Ik vind het moeilijk om met iemand samen te werken', 'Red', 1),
(116, 'Ik heb moeite met grapjes, plagerijtjes of spreekwoorden', 'Red', 1),
(117, 'Ik vind het moeilijk  om fouten te maken', 'Red', 1),
(118, 'Ik weet niet wat ik moet doen als ik een fout gemaakt heb', 'Red', 1),
(119, 'Ik vind het lastig om  op tijd te komen', 'Red', 1),
(120, 'Ik vind het moeilijk om hulp  te vragen bij een opdracht', 'Red', 1),
(121, 'Ik vind het moeilijk om te  horen dat ik iets niet goed gedaan heb', 'Red', 1),
(122, 'Ik vind het moeilijk om iets nieuws te leren', 'Red', 1),
(123, 'Ik denk vaak:  “wat moet ik nu gaan doen?”', 'Red', 1),
(124, 'Ik vind het lastig om met veranderingen om te gaan', 'Red', 1),
(125, 'Ik hoor vaak dat ik  te veel vragen stel', 'Red', 1),
(126, 'Ik heb last van geluid', 'Red', 1),
(127, 'Ik word snel afgeleid', 'Red', 1),
(128, 'Ik word snel boos  als iets niet lukt', 'Red', 1),
(129, 'Ik vind mijn eerste  werkdag moeilijk', 'Red', 1),
(130, 'Ik maak teveel fouten', 'Red', 1),
(131, 'Ik weet niet waar ik moet  gaan zitten in de pauze', 'Red', 1),
(132, 'Ik vind het moeilijk om  lang achter elkaar met hetzelfde bezig te zijn', 'Red', 1),
(133, 'Ik vind het lastig om mijn spullen op orde te hebben voor ik van huis vertrek', 'Red', 1),
(134, 'Mijn stemming kan  heel snel omslaan', 'Red', 1),
(135, 'Ik kan soms ineens  boos worden', 'Red', 1),
(136, 'Ik kan soms ineens  verdrietig zijn', 'Red', 1),
(137, 'Ik vind het lastig  me te concentreren  als er te veel prikkels zijn', 'Red', 1),
(138, 'Ik vind het lastig als ik  te weinig te doen heb', 'Red', 1),
(139, 'Ik vind het moeilijk als ik  niet heel precies weet wat ik moet doen', 'Red', 1),
(140, 'Ik vind het lastig om een  praatje te maken met collega’s in de pauze', 'Red', 1),
(141, 'Ik vind het lastig om mijn werk te plannen en te organiseren', 'Red', 1),
(142, 'Ik voel soms niet goed  aan wanneer ik even rust moet nemen', 'Red', 1),
(143, 'Ik vind het moeilijk om tegen mijn leidinggevende of collega’s te zeggen  dat ik even rust nodig heb', 'Red', 1),
(144, 'Als iemand iets uitlegt begrijp ik het soms  niet helemaal', 'Red', 1),
(145, 'Ik vind het moeilijk ergens naar toe te gaan waar ik nog nooit geweest ben', 'Red', 1),
(146, 'Ik vind het lastig om  aan mijn BPV-begeleider  te vragen om tijd voor mij  vrij te maken', 'Red', 1),
(147, 'Het lukt me niet om helemaal zelfstandig  een taak uit te voeren', 'Red', 1),
(148, 'Als verschillende mensen  mij opdrachten geven,  raak ik in de war', 'Red', 1),
(149, 'Ik vind het niet fijn als mensen me aanraken', 'Red', 1),
(150, 'Ik vind het moeilijk om meerdere taken/ opdrachten te onthouden', 'Red', 1),
(151, 'Ik vind het moeilijk om de hele stagedag vol te houden gelet op mijn energie', 'Red', 1),
(152, 'Ik vind het moeilijk om initiatief te nemen', 'Red', 1),
(153, 'Ik vind het moeilijk om onder tijdsdruk te werken', 'Red', 1),
(154, 'Ik vind het moeilijk om  te schakelen tussen taken', 'Red', 1),
(155, 'Ik werk langzaam,  mijn werktempo is laag', 'Red', 1),
(156, 'Vijf dagen werken  is te veel voor mij', 'Red', 1),
(157, 'Ik schrijf mijn vraag op  in mijn schriftje en stel  ze later op de dag  aan mijn begeleider', 'Yellow', 1),
(158, 'Ik vertel aan collega’s  dat ik dit moeilijk vind, eventueel samen met mijn vaste begeleider', 'Yellow', 1),
(159, 'Ik vraag dit aan mijn werkbegeleider', 'Yellow', 1),
(160, 'Ik bespreek dit met mijn werkbegeleider en we kijken samen met wie ik het beste een team kan vormen', 'Yellow', 1),
(161, 'Ik vraag aan mijn werkbegeleider wat er precies  fout is gegaan en bespreek hoe ik de fout kan herstellen', 'Yellow', 1),
(162, 'Ik vraag aan mijn ouders of andere huisgenoten of ze samen met mij de tijd in de gaten houden ‘s ochtends', 'Yellow', 1),
(163, 'Ik zeg tegen mezelf dat ik  aan het leren ben, nog niet alles weet en dus wel eens  om hulp moet vragen', 'Yellow', 1),
(164, 'Ik zeg tegen mezelf dat ik nog aan het leren ben, nog niet alles weet en dus ook niet altijd alles goed zal doen', 'Yellow', 1),
(165, 'Ik bespreek hoe ik het beste mijn pauze kan invullen;  bijvoorbeeld even naar  buiten of rustig alleen zitten met een boek', 'Yellow', 1),
(166, 'Ik spreek met  mijn werkbegeleider af hoeveel ik op een dag  af moet hebben', 'Yellow', 1),
(167, 'Ik vertel dit aan mijn werkbegeleider zodat  hij/zij hier rekening mee kan houden', 'Yellow', 1),
(168, 'Ik spreek af dat  er iemand in de buurt is  die mij in de gaten houdt', 'Yellow', 1),
(169, 'Ik vraag aan mijn werkbegeleider of hij  mij op tijd vertelt als er veranderingen komen', 'Yellow', 1),
(170, 'Ik vraag aan mijn  werkbegeleider wat precies  de afspraken zijn.  Ik vergeet niet me ook ziek  te melden bij school!', 'Yellow', 1),
(171, 'Ik leg uit hoe ik het best iets nieuws leer: door plaatjes,  door voordoen of een geschreven instructie', 'Yellow', 1),
(172, 'Ik vraag om een lijstje met voldoende werkzaamheden', 'Yellow', 1),
(173, 'Ik bespreek met mijn werkbegeleider of ik op  een rustigere werkplek  kan werken', 'Yellow', 1),
(174, 'Ik spreek af dat ik dan naar iemand toe kan, of even  naar buiten kan', 'Yellow', 1),
(175, 'Ik ga eerst een keer samen met iemand naar het werk;  ik schrijf op hoe ik  moet rijden', 'Yellow', 1),
(176, 'Voor de dag begint,  bespreek ik met mijn  begeleider wat ik kan gaan doen die dag en schrijf dit op', 'Yellow', 1),
(177, 'Ik bespreek met mijn werkbegeleider of de instructie  wat duidelijker gemaakt  kan worden voor mij', 'Yellow', 1),
(178, 'Ik spreek af dat ik herhaal  wat net is uitgelegd', 'Yellow', 1),
(179, 'Ik vraag om  afwisseling in taken', 'Yellow', 1),
(180, 'Ik vraag of ik even  een rondje mag lopen  als mijn hoofd erg vol i', 'Yellow', 1),
(181, 'Ik leg de avond van te voren al mijn spullen klaar', 'Yellow', 1),
(182, 'Ik maak een lijstje  van de spullen  die ik mee moet nemen', 'Yellow', 1),
(183, 'Ik neem even een moment  voor mezelf als ik merk dat  ik boos of verdrietig word,  daarna bespreek ik het  met mijn werkbegeleider', 'Yellow', 1),
(184, 'Ik zoek naar een  werkplek waar ik de  minste prikkels krijg', 'Yellow', 1),
(185, 'Ik oefen de vaardigheid  ‘een praatje maken’', 'Yellow', 1),
(186, 'Ik vraag mijn werkbegeleider om een overzicht van de werkzaamheden: waar,  met wie, wanneer en hoe', 'Yellow', 1),
(187, 'Ik maak een lijstje met  signalen waaraan ik kan zien/voelen dat ik rust nodig heb', 'Yellow', 1),
(188, 'Ik spreek met mijn werkbegeleider af dat  ik aangeef wanneer  mijn limiet bereikt is', 'Yellow', 1),
(189, 'Ik vraag om meer uitleg. Ik maak aantekeningen,  ik bespreek mijn aantekeningen', 'Yellow', 1),
(190, 'Ik spreek een teken af, waaraan mensen kunnen  zien dat ze me even met  rust moeten laten', 'Yellow', 1),
(191, 'Ik doe even iets  met mijn lijf  als het heel druk wordt  in mijn hoofd', 'Yellow', 1),
(192, 'Ik maak de reis naar mijn werk een keer van te voren (eventueel met iemand samen) en schrijf op: waar, wanneer, wat, hoe lang', 'Yellow', 1),
(193, 'Ik heb baat bij  duidelijke tools en tips', 'Yellow', 1),
(194, 'Ik heb regelmatig behoefte \r\n aan een compliment', 'Yellow', 1),
(195, 'Ik zeg tegen mezelf  dat het slim is om  vragen te stellen', 'Yellow', 1),
(196, 'Ik vertel dat ik het  niet fijn vind als mensen  me aanraken', 'Yellow', 1),
(197, 'Het is belangrijk  dat opdrachten zo veel mogelijk door één persoon gegeven worden', 'Yellow', 1),
(198, 'Ik vind het fijn als iemand regelmatig komt evalueren op mijn werkplek', 'Yellow', 1),
(199, 'We maken een maatwerkrooster in overleg met school en stage', 'Yellow', 1),
(200, 'Ik bespreek dat ik in kleuren (rood, geel, groen) of cijfers (1 tot en met 10) aangeef hoe ik me voel', 'Yellow', 1),
(201, 'Ik bespreek hoe ik mijn werktempo kan verhogen', 'Yellow', 1),
(202, 'Stagebegeleider', 'Blue', 1),
(203, 'Vriend of vriendin', 'Blue', 1),
(204, 'Werkbegeleider', 'Blue', 1),
(205, 'Collega', 'Blue', 1),
(206, 'Vader of moeder', 'Blue', 1),
(207, 'Adviseur  passend onderwijs', 'Blue', 1),
(208, 'Klasgenoot', 'Blue', 1),
(209, 'Jobcoach', 'Blue', 1),
(210, 'Ikzelf', 'Blue', 1),
(211, 'Mentor', 'Blue', 1);

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
-- Tabelstructuur voor tabel `users`
--

DROP TABLE IF EXISTS `users`;
CREATE TABLE IF NOT EXISTS `users` (
  `UserID` int(11) NOT NULL AUTO_INCREMENT,
  `Username` varchar(100) NOT NULL,
  `Password` varchar(100) NOT NULL,
  PRIMARY KEY (`UserID`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

--
-- Gegevens worden geëxporteerd voor tabel `users`
--

INSERT INTO `users` (`UserID`, `Username`, `Password`) VALUES
(1, 'admin', 'summa2020');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
