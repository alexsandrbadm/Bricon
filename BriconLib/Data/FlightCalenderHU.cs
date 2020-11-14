﻿// Decompiled with JetBrains decompiler
// Type: BriconLib.Data.FlightCalenderHU
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

namespace BriconLib.Data
{
  internal class FlightCalenderHU
  {
    private static void ADD(string name, string code, int X, int Y)
    {
      if (code == null)
        code = name.Replace("'", "").Replace("-", "").Replace(" ", "").Replace(".", "").PadRight(4).Substring(0, 4);
      BCEDatabase.DataSet.Lossingsplaats.AddLossingsplaatsRow(name, code, X, Y, false, "", "HU", 1, 0, 0, "");
    }

    public static void AddFlights(bool clearFirst)
    {
      if (clearFirst)
        BCEDatabase.DataSet.Lossingsplaats.Clear();
      FlightCalenderHU.ADD("AACHEN", (string) null, 5048530, 612540);
      FlightCalenderHU.ADD("ABDA", (string) null, 4741313, 1733095);
      FlightCalenderHU.ADD("ABONY", (string) null, 4711050, 2002480);
      FlightCalenderHU.ADD("AGFALVA", (string) null, 4741130, 1631120);
      FlightCalenderHU.ADD("AGFALVA-ORSZAGHATAR", (string) null, 4744030, 1624210);
      FlightCalenderHU.ADD("ALLAND", (string) null, 4803300, 1603400);
      FlightCalenderHU.ADD("AMBERG", (string) null, 4925044, 1154537);
      FlightCalenderHU.ADD("AMSTETTEN", (string) null, 4808240, 1451570);
      FlightCalenderHU.ADD("ARENDONK", (string) null, 5119000, 505000);
      FlightCalenderHU.ADD("AS", (string) null, 5012570, 1212180);
      FlightCalenderHU.ADD("ASCHAFFENBURG", (string) null, 4959364, 904068);
      FlightCalenderHU.ADD("AURACH", (string) null, 4914581, 1026021);
      FlightCalenderHU.ADD("BABOLNA", (string) null, 4738220, 1759210);
      FlightCalenderHU.ADD("BAIA MARE", (string) null, 4739010, 2332260);
      FlightCalenderHU.ADD("BALASSAGYARMAT", (string) null, 4804109, 1916193);
      FlightCalenderHU.ADD("BALF", (string) null, 4738380, 1640120);
      FlightCalenderHU.ADD("BAMBERG", (string) null, 4955432, 1046154);
      FlightCalenderHU.ADD("BARCS", (string) null, 4558330, 1727320);
      FlightCalenderHU.ADD("BARTH", (string) null, 5421550, 1242180);
      FlightCalenderHU.ADD("BARUTH", (string) null, 5202420, 1330090);
      FlightCalenderHU.ADD("BATTONYA", (string) null, 4616420, 2100110);
      FlightCalenderHU.ADD("BAUTZEN", (string) null, 5112000, 1419540);
      FlightCalenderHU.ADD("BEKESCSABA", (string) null, 4640450, 2104150);
      FlightCalenderHU.ADD("BENESOV", (string) null, 4946480, 1442160);
      FlightCalenderHU.ADD("BEOGRAD", (string) null, 4449030, 2036060);
      FlightCalenderHU.ADD("BEREGSURANY", (string) null, 4809480, 2232380);
      FlightCalenderHU.ADD("BERETTYOUJFALU", (string) null, 4714230, 2131040);
      FlightCalenderHU.ADD("BERLIN-FAHRLAND", (string) null, 5227450, 1257420);
      FlightCalenderHU.ADD("BICSKE", (string) null, 4730050, 1837360);
      FlightCalenderHU.ADD("BIHARKERESZTES", (string) null, 4708030, 2142170);
      FlightCalenderHU.ADD("BRANDENBURG", (string) null, 5225140, 1233450);
      FlightCalenderHU.ADD("BRATISLAVA", (string) null, 4810000, 1702000);
      FlightCalenderHU.ADD("BRECLAV", (string) null, 4845060, 1653550);
      FlightCalenderHU.ADD("BREMEN", (string) null, 5302100, 858240);
      FlightCalenderHU.ADD("BRNO", (string) null, 4910280, 1635430);
      FlightCalenderHU.ADD("BRNO-DEL", (string) null, 4907380, 1637270);
      FlightCalenderHU.ADD("BRUCK AN DER LEITHA", (string) null, 4802370, 1645320);
      FlightCalenderHU.ADD("BRUXELLES", (string) null, 5048390, 421480);
      FlightCalenderHU.ADD("BUCURESTI", (string) null, 4428240, 2558200);
      FlightCalenderHU.ADD("BUDAORS", (string) null, 4727210, 1858210);
      FlightCalenderHU.ADD("BUDAPEST-CINKOTA", (string) null, 4732080, 1914430);
      FlightCalenderHU.ADD("BUJANOVAC", (string) null, 4227250, 2147070);
      FlightCalenderHU.ADD("CEGLED", (string) null, 4710320, 1949365);
      FlightCalenderHU.ADD("CELJE", (string) null, 4613340, 1518070);
      FlightCalenderHU.ADD("CESKA LIPA", (string) null, 5040080, 1432250);
      FlightCalenderHU.ADD("CESKE BUDEJOVICE", (string) null, 4859090, 1431040);
      FlightCalenderHU.ADD("CHEB", (string) null, 5005120, 1223530);
      FlightCalenderHU.ADD("CHOMUTOV", (string) null, 5026510, 1326020);
      FlightCalenderHU.ADD("CHRUDIM", (string) null, 4956170, 1547232);
      FlightCalenderHU.ADD("CINOVEC", (string) null, 5044040, 1345270);
      FlightCalenderHU.ADD("CLUJ", (string) null, 4645230, 2332230);
      FlightCalenderHU.ADD("CONSTANZA", (string) null, 4410480, 2835450);
      FlightCalenderHU.ADD("COTTBUS", (string) null, 5144000, 1418590);
      FlightCalenderHU.ADD("CRAJOVA", (string) null, 4419530, 2345240);
      FlightCalenderHU.ADD("CRIVITZ", (string) null, 5334390, 1138040);
      FlightCalenderHU.ADD("CSENGER", (string) null, 4750290, 2240300);
      FlightCalenderHU.ADD("CSORNA", (string) null, 4736500, 1715500);
      FlightCalenderHU.ADD("DEBRECEN", (string) null, 4730270, 2135360);
      FlightCalenderHU.ADD("DEGGENDORF", (string) null, 4850090, 1258340);
      FlightCalenderHU.ADD("DESSAU", (string) null, 5153365, 1215565);
      FlightCalenderHU.ADD("DIVISOV", (string) null, 4947320, 1452550);
      FlightCalenderHU.ADD("DOMBOVAR", (string) null, 4623220, 1808400);
      FlightCalenderHU.ADD("DOBELN", (string) null, 5108555, 1306452);
      FlightCalenderHU.ADD("DRAHONICE", (string) null, 4911540, 1405030);
      FlightCalenderHU.ADD("DRASENHOFEN", (string) null, 4845517, 1638453);
      FlightCalenderHU.ADD("DRESDEN FREITHAL", (string) null, 5100450, 1343330);
      FlightCalenderHU.ADD("DUBEN", (string) null, 5153272, 1347577);
      FlightCalenderHU.ADD("DUNAFOLDVAR", (string) null, 4648070, 1855010);
      FlightCalenderHU.ADD("EINDHOVEN", (string) null, 5126120, 532130);
      FlightCalenderHU.ADD("EISENACH", (string) null, 5055000, 1022000);
      FlightCalenderHU.ADD("FELSOSZOLNOK", (string) null, 4652390, 1610100);
      FlightCalenderHU.ADD("FINSTERWALDE", (string) null, 5137554, 1344223);
      FlightCalenderHU.ADD("FRANKFURT AN DER ODER", (string) null, 5218153, 1428546);
      FlightCalenderHU.ADD("FREISTADT", (string) null, 4830400, 1430180);
      FlightCalenderHU.ADD("FUZESABONY", (string) null, 4745340, 2023380);
      FlightCalenderHU.ADD("GARDELEGEN", (string) null, 5231350, 1123410);
      FlightCalenderHU.ADD("GDANSK", (string) null, 5419250, 1837520);
      FlightCalenderHU.ADD("GEISLING", (string) null, 4858050, 1220040);
      FlightCalenderHU.ADD("GEVGELIJA", (string) null, 4108580, 2229320);
      FlightCalenderHU.ADD("GORZOW", (string) null, 5242390, 1515120);
      FlightCalenderHU.ADD("GODOLLO", (string) null, 4737220, 1921270);
      FlightCalenderHU.ADD("GONYU", (string) null, 4743470, 1750450);
      FlightCalenderHU.ADD("GOPFRITZ", (string) null, 4844400, 1522120);
      FlightCalenderHU.ADD("GRIMMA", (string) null, 5115202, 1242505);
      FlightCalenderHU.ADD("GROSSRASCHEN", (string) null, 5134511, 1401134);
      FlightCalenderHU.ADD("GYOMA", (string) null, 4655570, 2048270);
      FlightCalenderHU.ADD("GYOR", (string) null, 4741380, 1740130);
      FlightCalenderHU.ADD("GYONGYOS", (string) null, 4746180, 1955190);
      FlightCalenderHU.ADD("GYULA", (string) null, 4639050, 2114220);
      FlightCalenderHU.ADD("HAAG", (string) null, 4806580, 1434430);
      FlightCalenderHU.ADD("HAJDUSZOBOSZLO", (string) null, 4726120, 2122290);
      FlightCalenderHU.ADD("HALLE", (string) null, 5128586, 1203278);
      FlightCalenderHU.ADD("HAMBURG-HORST", (string) null, 5348230, 940320);
      FlightCalenderHU.ADD("HANNOVER", (string) null, 5222040, 953020);
      FlightCalenderHU.ADD("HATVAN", (string) null, 4739530, 1939090);
      FlightCalenderHU.ADD("HAUGSDORF", (string) null, 4842000, 1610000);
      FlightCalenderHU.ADD("HAVLICKUV BROD", (string) null, 4935480, 1533240);
      FlightCalenderHU.ADD("HEGYESHALOM", (string) null, 4754350, 1710260);
      FlightCalenderHU.ADD("HERZBERG", (string) null, 5141490, 1315020);
      FlightCalenderHU.ADD("HODMEZOVASARHELY", (string) null, 4625520, 2017570);
      FlightCalenderHU.ADD("HODONIN", (string) null, 4850533, 1705326);
      FlightCalenderHU.ADD("HOLIC", (string) null, 4848010, 1709280);
      FlightCalenderHU.ADD("HOLICE", (string) null, 5003386, 1559533);
      FlightCalenderHU.ADD("HOLLABRUNN", (string) null, 4829100, 1607300);
      FlightCalenderHU.ADD("HORICE", (string) null, 4935522, 1511186);
      FlightCalenderHU.ADD("HORKY", (string) null, 4905252, 1541107);
      FlightCalenderHU.ADD("HORN", (string) null, 4839400, 1539540);
      FlightCalenderHU.ADD("HOYERSWERDA", (string) null, 5125432, 1414443);
      FlightCalenderHU.ADD("HRADEC KRALOVE", (string) null, 5012070, 1546470);
      FlightCalenderHU.ADD("HRANICE", (string) null, 5017340, 1210370);
      FlightCalenderHU.ADD("HUMPOLEC", (string) null, 4931510, 1522060);
      FlightCalenderHU.ADD("HUSTOPECE", (string) null, 4857130, 1645530);
      FlightCalenderHU.ADD("ISTANBUL", (string) null, 4103470, 2858590);
      FlightCalenderHU.ADD("JENA", (string) null, 5054400, 1135230);
      FlightCalenderHU.ADD("JIHLAVA", (string) null, 4925420, 1536170);
      FlightCalenderHU.ADD("KACOV", (string) null, 4946420, 1500570);
      FlightCalenderHU.ADD("KAMENICE", (string) null, 4952000, 1437000);
      FlightCalenderHU.ADD("KAMENZ", (string) null, 5116100, 1406200);
      FlightCalenderHU.ADD("KAPOSVAR", (string) null, 4622240, 1749380);
      FlightCalenderHU.ADD("KAPUVAR", (string) null, 4735380, 1702070);
      FlightCalenderHU.ADD("KARLOVY VARY", (string) null, 5012000, 1253000);
      FlightCalenderHU.ADD("KASSEL", (string) null, 5115425, 927185);
      FlightCalenderHU.ADD("KATOWICE", (string) null, 5013270, 1859060);
      FlightCalenderHU.ADD("KECSKEMET", (string) null, 4655270, 1940240);
      FlightCalenderHU.ADD("KIEL", (string) null, 5410535, 1013090);
      FlightCalenderHU.ADD("KISBER", (string) null, 4729480, 1802450);
      FlightCalenderHU.ADD("KISVARDA", (string) null, 4814180, 2203390);
      FlightCalenderHU.ADD("KLADNO", (string) null, 5007494, 1400132);
      FlightCalenderHU.ADD("KOBLENZ", (string) null, 5024210, 736500);
      FlightCalenderHU.ADD("KOLIN", (string) null, 5001030, 1512470);
      FlightCalenderHU.ADD("KOMARNO", (string) null, 4745550, 1805400);
      FlightCalenderHU.ADD("KOMAROM", (string) null, 4744000, 1809170);
      FlightCalenderHU.ADD("KOPHAZA", (string) null, 4737560, 1638310);
      FlightCalenderHU.ADD("KORNEUBURG", (string) null, 4819210, 1619380);
      FlightCalenderHU.ADD("KOSICE", (string) null, 4840070, 2115460);
      FlightCalenderHU.ADD("KOSZALIN", (string) null, 5410390, 1612000);
      FlightCalenderHU.ADD("KOLN", (string) null, 5053470, 705460);
      FlightCalenderHU.ADD("KOSZEG", (string) null, 4722464, 1632590);
      FlightCalenderHU.ADD("KRAKOW SKAWINA", (string) null, 4957480, 1949250);
      FlightCalenderHU.ADD("KREMS", (string) null, 4825180, 1537440);
      FlightCalenderHU.ADD("KUTY", (string) null, 4839090, 1700580);
      FlightCalenderHU.ADD("KYRITZ", (string) null, 5256210, 1223470);
      FlightCalenderHU.ADD("LEIPZIG", (string) null, 5120000, 1228500);
      FlightCalenderHU.ADD("LESKOVAC", (string) null, 4300270, 2156030);
      FlightCalenderHU.ADD("LESNO", (string) null, 5150060, 1635100);
      FlightCalenderHU.ADD("LETENYE", (string) null, 4626150, 1644200);
      FlightCalenderHU.ADD("LETOVICE", (string) null, 4932150, 1635200);
      FlightCalenderHU.ADD("LEVICE", (string) null, 4813040, 1837501);
      FlightCalenderHU.ADD("LIBEREC", (string) null, 5044550, 1503290);
      FlightCalenderHU.ADD("LIEGE", (string) null, 5039100, 542320);
      FlightCalenderHU.ADD("LINZ-TRAUN", (string) null, 4814040, 1414010);
      FlightCalenderHU.ADD("LISOV", (string) null, 4900520, 1437230);
      FlightCalenderHU.ADD("LITOMERICE", (string) null, 5030180, 1403170);
      FlightCalenderHU.ADD("LJUBLJANA", (string) null, 4605530, 1428140);
      FlightCalenderHU.ADD("LOVOSICE", (string) null, 5030000, 1402000);
      FlightCalenderHU.ADD("LUBBENAU", (string) null, 5151370, 1357070);
      FlightCalenderHU.ADD("LVOV", (string) null, 4947030, 2401250);
      FlightCalenderHU.ADD("MAGDEBURG", (string) null, 5209407, 1130187);
      FlightCalenderHU.ADD("MAKO", (string) null, 4612380, 2027150);
      FlightCalenderHU.ADD("MALACKY", (string) null, 4825280, 1701080);
      FlightCalenderHU.ADD("MARCALI", (string) null, 4635220, 1725020);
      FlightCalenderHU.ADD("MARKTREDWITZ", (string) null, 5000580, 1204360);
      FlightCalenderHU.ADD("MATESZALKA", (string) null, 4756250, 2218070);
      FlightCalenderHU.ADD("MELK", (string) null, 4813140, 1520460);
      FlightCalenderHU.ADD("MEZOKOVESD", (string) null, 4748190, 2033090);
      FlightCalenderHU.ADD("MIKULOV", (string) null, 4848030, 1639080);
      FlightCalenderHU.ADD("MISKOLC", (string) null, 4802530, 2047530);
      FlightCalenderHU.ADD("MLADA BOLESLAV", (string) null, 5023590, 1454020);
      FlightCalenderHU.ADD("MOHACS", (string) null, 4600000, 1840250);
      FlightCalenderHU.ADD("MOR", (string) null, 4722150, 1811340);
      FlightCalenderHU.ADD("MOSONMAGYAROVAR", (string) null, 4750530, 1716510);
      FlightCalenderHU.ADD("MOST", (string) null, 5031020, 1338270);
      FlightCalenderHU.ADD("MODLING", (string) null, 4805090, 1619230);
      FlightCalenderHU.ADD("NACHOD", (string) null, 5024210, 1608380);
      FlightCalenderHU.ADD("NAGYKANIZSA", (string) null, 4628180, 1659220);
      FlightCalenderHU.ADD("NAGYKOROS", (string) null, 4702410, 1946480);
      FlightCalenderHU.ADD("NARDA", (string) null, 4714230, 1628220);
      FlightCalenderHU.ADD("NASAVRKY", (string) null, 4950372, 1547519);
      FlightCalenderHU.ADD("NEUDORFL", (string) null, 4748313, 1618191);
      FlightCalenderHU.ADD("NEUMARKT", (string) null, 4920060, 1126145);
      FlightCalenderHU.ADD("NICKELSDORF", (string) null, 4756060, 1705250);
      FlightCalenderHU.ADD("NIS", (string) null, 4319480, 2152550);
      FlightCalenderHU.ADD("NITRA", (string) null, 4817060, 1804340);
      FlightCalenderHU.ADD("NOVA VES", (string) null, 5017080, 1418310);
      FlightCalenderHU.ADD("NOVI SAD", (string) null, 4518030, 1949120);
      FlightCalenderHU.ADD("NURNBERG JURA", (string) null, 4915360, 1136030);
      FlightCalenderHU.ADD("NURNBERG LANGWASSER", (string) null, 4924270, 1110070);
      FlightCalenderHU.ADD("NYEKLADHAZA", (string) null, 4759290, 2050570);
      FlightCalenderHU.ADD("NYIRABRANY", (string) null, 4732570, 2201140);
      FlightCalenderHU.ADD("NYIREGYHAZA", (string) null, 4757330, 2141410);
      FlightCalenderHU.ADD("OHRAZENICE", (string) null, 5035422, 1507171);
      FlightCalenderHU.ADD("OLOMOUC", (string) null, 4934340, 1717570);
      FlightCalenderHU.ADD("OPOLE", (string) null, 5039420, 1754180);
      FlightCalenderHU.ADD("OSTENDE", (string) null, 5155000, 255000);
      FlightCalenderHU.ADD("OSTRAVA", (string) null, 4949484, 1817285);
      FlightCalenderHU.ADD("OSTROW", (string) null, 5137190, 1748380);
      FlightCalenderHU.ADD("OTTEVENY", (string) null, 4743130, 1730000);
      FlightCalenderHU.ADD("PANNONHALMA", (string) null, 4732250, 1743334);
      FlightCalenderHU.ADD("PARDUBICE", (string) null, 5001300, 1546040);
      FlightCalenderHU.ADD("PARNDORF", (string) null, 4758310, 1650050);
      FlightCalenderHU.ADD("PASSAU", (string) null, 4833450, 1326080);
      FlightCalenderHU.ADD("PECS-FELSO", (string) null, 4605170, 1817020);
      FlightCalenderHU.ADD("PERLEBERG", (string) null, 5304330, 1151420);
      FlightCalenderHU.ADD("PESTIMRE", (string) null, 4724570, 1910160);
      FlightCalenderHU.ADD("PFAFFENHOFEN", (string) null, 4832000, 1129180);
      FlightCalenderHU.ADD("PIESTANY", (string) null, 4835250, 1747540);
      FlightCalenderHU.ADD("PLZEN", (string) null, 4942000, 1325000);
      FlightCalenderHU.ADD("POLGAR", (string) null, 4750590, 2107020);
      FlightCalenderHU.ADD("POREC", (string) null, 4514020, 1335470);
      FlightCalenderHU.ADD("POZNAN", (string) null, 5221390, 1650320);
      FlightCalenderHU.ADD("PRAHA CHODOK", (string) null, 5001300, 1430450);
      FlightCalenderHU.ADD("PRAMERDORF", (string) null, 4825530, 1327154);
      FlightCalenderHU.ADD("PRIBYSLAVICE", (string) null, 4916113, 1616362);
      FlightCalenderHU.ADD("PULA", (string) null, 4453030, 1351300);
      FlightCalenderHU.ADD("PUSPOKLADANY", (string) null, 4719160, 2104580);
      FlightCalenderHU.ADD("RADEBURG", (string) null, 5113100, 1344300);
      FlightCalenderHU.ADD("RADOM", (string) null, 5124520, 2112360);
      FlightCalenderHU.ADD("RAJKA", (string) null, 4759190, 1712130);
      FlightCalenderHU.ADD("RATOT", (string) null, 4657220, 1625030);
      FlightCalenderHU.ADD("REGENSBURG", (string) null, 4858554, 1213243);
      FlightCalenderHU.ADD("REKAWINKEL", (string) null, 4810000, 1601000);
      FlightCalenderHU.ADD("RICAN", (string) null, 4959110, 1439270);
      FlightCalenderHU.ADD("RIESA", (string) null, 5117220, 1317540);
      FlightCalenderHU.ADD("ROMA", (string) null, 4208047, 1236026);
      FlightCalenderHU.ADD("ROSICE", (string) null, 4911085, 1625002);
      FlightCalenderHU.ADD("ROSTOCK", (string) null, 5404170, 1209420);
      FlightCalenderHU.ADD("RUSOVCE", (string) null, 4803290, 1708120);
      FlightCalenderHU.ADD("SAL'A", (string) null, 4809390, 1752530);
      FlightCalenderHU.ADD("SALGOTARJAN", (string) null, 4805330, 1947220);
      FlightCalenderHU.ADD("SALZBURG", (string) null, 4750060, 1303020);
      FlightCalenderHU.ADD("SAMORIN", (string) null, 4801240, 1719130);
      FlightCalenderHU.ADD("SANKT POLTEN", (string) null, 4811330, 1538380);
      FlightCalenderHU.ADD("SAROSPATAK", (string) null, 4819570, 2134330);
      FlightCalenderHU.ADD("SARVAR", (string) null, 4714490, 1656440);
      FlightCalenderHU.ADD("SATORALJAUJHELY", (string) null, 4824530, 2136250);
      FlightCalenderHU.ADD("SCHERDING", (string) null, 4825020, 1326080);
      FlightCalenderHU.ADD("SCHREMS", (string) null, 4847330, 1504570);
      FlightCalenderHU.ADD("SCHWABISCH HALL", (string) null, 4907340, 944410);
      FlightCalenderHU.ADD("SCHWERIN", (string) null, 5335570, 1126440);
      FlightCalenderHU.ADD("SEREGELYES", (string) null, 4706188, 1833205);
      FlightCalenderHU.ADD("SIBIU", (string) null, 4547210, 2406200);
      FlightCalenderHU.ADD("SIMONTORNYA", (string) null, 4645390, 1832240);
      FlightCalenderHU.ADD("SKOPJE KUMANOVO", (string) null, 4208220, 2142570);
      FlightCalenderHU.ADD("SLANY", (string) null, 5013270, 1405310);
      FlightCalenderHU.ADD("SMOLENICE", (string) null, 4830393, 1726441);
      FlightCalenderHU.ADD("SOPRON", (string) null, 4740260, 1636210);
      FlightCalenderHU.ADD("SOUTICE", (string) null, 4943250, 1503210);
      FlightCalenderHU.ADD("SPREMBERG", (string) null, 5133106, 1422333);
      FlightCalenderHU.ADD("STEENBERGEN", (string) null, 5135300, 420300);
      FlightCalenderHU.ADD("STENDAL", (string) null, 5235202, 1153330);
      FlightCalenderHU.ADD("STOCKERAU", (string) null, 4823250, 1610416);
      FlightCalenderHU.ADD("STRAUBING", (string) null, 4853025, 1233545);
      FlightCalenderHU.ADD("STREHLA", (string) null, 5120570, 1314210);
      FlightCalenderHU.ADD("STUDENY", (string) null, 4936276, 1508038);
      FlightCalenderHU.ADD("SUWALKI", (string) null, 5402560, 2256150);
      FlightCalenderHU.ADD("SVETOZAREVO", (string) null, 4358550, 2114350);
      FlightCalenderHU.ADD("SVITAVY", (string) null, 4944560, 1628490);
      FlightCalenderHU.ADD("SZCZECIN", (string) null, 5322110, 1442050);
      FlightCalenderHU.ADD("SZEGED", (string) null, 4617070, 2004330);
      FlightCalenderHU.ADD("SZEKESFEHERVAR", (string) null, 4710580, 1827380);
      FlightCalenderHU.ADD("SZEKSZARD", (string) null, 4621470, 1842130);
      FlightCalenderHU.ADD("SZENTGOTTHARD", (string) null, 4657010, 1618280);
      FlightCalenderHU.ADD("SZIGETVAR", (string) null, 4603160, 1747250);
      FlightCalenderHU.ADD("SZOLNOK", (string) null, 4710350, 2009100);
      FlightCalenderHU.ADD("SZOMBATHELY", (string) null, 4714210, 1639000);
      FlightCalenderHU.ADD("TABOR", (string) null, 4921210, 1443150);
      FlightCalenderHU.ADD("TAMASI", (string) null, 4638330, 1816310);
      FlightCalenderHU.ADD("TANGERMUNDE", (string) null, 5233317, 1158524);
      FlightCalenderHU.ADD("TASOV", (string) null, 4917420, 1606080);
      FlightCalenderHU.ADD("TATA-KORNYE", (string) null, 4736310, 1823260);
      FlightCalenderHU.ADD("TEPLICE", (string) null, 5037580, 1351370);
      FlightCalenderHU.ADD("TEPLICE HROB", (string) null, 5039120, 1343120);
      FlightCalenderHU.ADD("TIMISOARA", (string) null, 4547010, 2113110);
      FlightCalenderHU.ADD("TISZABECS", (string) null, 4806070, 2249200);
      FlightCalenderHU.ADD("TOMPA", (string) null, 4614480, 1931540);
      FlightCalenderHU.ADD("TORGAU", (string) null, 5131526, 1256096);
      FlightCalenderHU.ADD("TORNYOSNEMEDI", (string) null, 4831160, 2115070);
      FlightCalenderHU.ADD("TREBIC", (string) null, 4909000, 1558000);
      FlightCalenderHU.ADD("TRIEST KOZINA", (string) null, 4536320, 1355320);
      FlightCalenderHU.ADD("TRNAVA", (string) null, 4821560, 1736120);
      FlightCalenderHU.ADD("UHERSKE HRADISTE", (string) null, 4902320, 1728250);
      FlightCalenderHU.ADD("UZSGOROD", (string) null, 4837170, 2217330);
      FlightCalenderHU.ADD("V. BERANOV", (string) null, 4924420, 1540070);
      FlightCalenderHU.ADD("VAGUJHELY", (string) null, 4845430, 1751120);
      FlightCalenderHU.ADD("VARNA", (string) null, 4313040, 2752150);
      FlightCalenderHU.ADD("VARPALOTA", (string) null, 4712086, 1809056);
      FlightCalenderHU.ADD("VECSES", (string) null, 4724350, 1916330);
      FlightCalenderHU.ADD("VELES", (string) null, 4143500, 2147480);
      FlightCalenderHU.ADD("VELKA BITES", (string) null, 4916404, 1613314);
      FlightCalenderHU.ADD("VELKA MEZIRICI", (string) null, 4921000, 1558000);
      FlightCalenderHU.ADD("VENEZIA MIRA", (string) null, 4525510, 1208190);
      FlightCalenderHU.ADD("VESZPREM", (string) null, 4706040, 1753050);
      FlightCalenderHU.ADD("VRANOV", (string) null, 4951440, 1447160);
      FlightCalenderHU.ADD("VYSOKE MYTO", (string) null, 4957248, 1609598);
      FlightCalenderHU.ADD("WALCHSHAUSEN", (string) null, 4814081, 1330225);
      FlightCalenderHU.ADD("WEIDEN", (string) null, 4939100, 1207440);
      FlightCalenderHU.ADD("WEISENBURG", (string) null, 4901160, 1059240);
      FlightCalenderHU.ADD("WEITERSFELDEN", (string) null, 4828350, 1443310);
      FlightCalenderHU.ADD("WELS", (string) null, 4808350, 1401560);
      FlightCalenderHU.ADD("WIESBADEN", (string) null, 5005040, 814320);
      FlightCalenderHU.ADD("WITTSTOCK", (string) null, 5307140, 1228110);
      FlightCalenderHU.ADD("WROCLAW", (string) null, 5104070, 1659310);
      FlightCalenderHU.ADD("WURZBURG", (string) null, 4945470, 956080);
      FlightCalenderHU.ADD("WURZBURG-HEIDINGSFELD", (string) null, 4944180, 956050);
      FlightCalenderHU.ADD("YBBS", (string) null, 4809010, 1506100);
      FlightCalenderHU.ADD("ZAGREB SESVETO", (string) null, 4549260, 1605260);
      FlightCalenderHU.ADD("ZAHONY", (string) null, 4824020, 2210240);
      FlightCalenderHU.ADD("ZALAEGERSZEG", (string) null, 4651070, 1651030);
      FlightCalenderHU.ADD("ZIELONA GORA", (string) null, 5155460, 1531340);
      FlightCalenderHU.ADD("ZILINA", (string) null, 4912550, 1845250);
      FlightCalenderHU.ADD("ZNOJMO", (string) null, 4850000, 1609050);
      BCEDatabase.SaveFlights();
    }
  }
}
