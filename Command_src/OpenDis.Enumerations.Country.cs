using System;
using System.ComponentModel;
using OpenDis.Core;

namespace OpenDis.Enumerations;

[Serializable]
public enum Country : ushort
{
	[InternetDomainCode("Unknown")]
	[Description("Other")]
	Other = 0,
	[Description("Afghanistan")]
	[InternetDomainCode("AF")]
	Afghanistan = 1,
	[Description("Albania")]
	[InternetDomainCode("AL")]
	Albania = 2,
	[InternetDomainCode("DZ")]
	[Description("Algeria")]
	Algeria = 3,
	[InternetDomainCode("Unknown")]
	[Description("American Samoa (United States)")]
	AmericanSamoaUnitedStates = 4,
	[Description("Andorra")]
	[InternetDomainCode("AD")]
	Andorra = 5,
	[InternetDomainCode("AO")]
	[Description("Angola")]
	Angola = 6,
	[Description("Anguilla")]
	[InternetDomainCode("AI")]
	Anguilla = 7,
	[Description("Antarctica (International)")]
	[InternetDomainCode("Unknown")]
	AntarcticaInternational = 8,
	[Description("Antigua and Barbuda")]
	[InternetDomainCode("AG")]
	AntiguaAndBarbuda = 9,
	[Description("Argentina")]
	[InternetDomainCode("AR")]
	Argentina = 10,
	[Description("Armenia")]
	[InternetDomainCode("AM")]
	Armenia = 244,
	[InternetDomainCode("AW")]
	[Description("Aruba")]
	Aruba = 11,
	[InternetDomainCode("Unknown")]
	[Description("Ashmore and Cartier Islands (Australia)")]
	AshmoreAndCartierIslandsAustralia = 12,
	[Description("Australia")]
	[InternetDomainCode("AU")]
	Australia = 13,
	[Description("Austria")]
	[InternetDomainCode("AT")]
	Austria = 14,
	[InternetDomainCode("AZ")]
	[Description("Azerbaijan")]
	Azerbaijan = 245,
	[InternetDomainCode("BS")]
	[Description("Bahamas")]
	Bahamas = 15,
	[Description("Bahrain")]
	[InternetDomainCode("BH")]
	Bahrain = 16,
	[InternetDomainCode("Unknown")]
	[Description("Baker Island (United States)")]
	BakerIslandUnitedStates = 17,
	[InternetDomainCode("BD")]
	[Description("Bangladesh")]
	Bangladesh = 18,
	[Description("Barbados")]
	[InternetDomainCode("BB")]
	Barbados = 19,
	[Description("Bassas da India (France)")]
	[InternetDomainCode("Unknown")]
	BassasDaIndiaFrance = 20,
	[Description("Belarus")]
	[InternetDomainCode("BY")]
	Belarus = 246,
	[Description("Belgium")]
	[InternetDomainCode("BE")]
	Belgium = 21,
	[Description("Belize")]
	[InternetDomainCode("BZ")]
	Belize = 22,
	[Description("Benin (aka Dahomey)")]
	[InternetDomainCode("Unknown")]
	BeninAkaDahomey = 23,
	[Description("Bermuda (United Kingdom)")]
	[InternetDomainCode("Unknown")]
	BermudaUnitedKingdom = 24,
	[Description("Bhutan")]
	[InternetDomainCode("BT")]
	Bhutan = 25,
	[InternetDomainCode("BO")]
	[Description("Bolivia")]
	Bolivia = 26,
	[Description("Bosnia and Hercegovina")]
	[InternetDomainCode("Unknown")]
	BosniaAndHercegovina = 247,
	[Description("Botswana")]
	[InternetDomainCode("BW")]
	Botswana = 27,
	[Description("Bouvet Island (Norway)")]
	[InternetDomainCode("Unknown")]
	BouvetIslandNorway = 28,
	[Description("Brazil")]
	[InternetDomainCode("BR")]
	Brazil = 29,
	[Description("British Indian Ocean Territory (United Kingdom)")]
	[InternetDomainCode("Unknown")]
	BritishIndianOceanTerritoryUnitedKingdom = 30,
	[Description("British Virgin Islands (United Kingdom)")]
	[InternetDomainCode("Unknown")]
	BritishVirginIslandsUnitedKingdom = 31,
	[Description("Brunei")]
	[InternetDomainCode("Unknown")]
	Brunei = 32,
	[Description("Bulgaria")]
	[InternetDomainCode("BG")]
	Bulgaria = 33,
	[Description("Burkina (aka Burkina Faso or Upper Volta)")]
	[InternetDomainCode("Unknown")]
	BurkinaAkaBurkinaFasoOrUpperVolta = 34,
	[InternetDomainCode("Unknown")]
	[Description("Burma (Myanmar)")]
	BurmaMyanmar = 35,
	[Description("Burundi")]
	[InternetDomainCode("BI")]
	Burundi = 36,
	[Description("Cambodia (aka Kampuchea)")]
	[InternetDomainCode("Unknown")]
	CambodiaAkaKampuchea = 37,
	[Description("Cameroon")]
	[InternetDomainCode("CM")]
	Cameroon = 38,
	[Description("Canada")]
	[InternetDomainCode("CA")]
	Canada = 39,
	[Description("Cape Verde, Republic of")]
	[InternetDomainCode("Unknown")]
	CapeVerdeRepublicOf = 40,
	[Description("Cayman Islands (United Kingdom)")]
	[InternetDomainCode("Unknown")]
	CaymanIslandsUnitedKingdom = 41,
	[Description("Central African Republic")]
	[InternetDomainCode("CF")]
	CentralAfricanRepublic = 42,
	[InternetDomainCode("TD")]
	[Description("Chad")]
	Chad = 43,
	[InternetDomainCode("CL")]
	[Description("Chile")]
	Chile = 44,
	[InternetDomainCode("Unknown")]
	[Description("China, People's Republic of")]
	ChinaPeopleSRepublicOf = 45,
	[Description("Christmas Island (Australia)")]
	[InternetDomainCode("Unknown")]
	ChristmasIslandAustralia = 46,
	[Description("Clipperton Island (France)")]
	[InternetDomainCode("Unknown")]
	ClippertonIslandFrance = 248,
	[Description("Cocos (Keeling) Islands (Australia)")]
	[InternetDomainCode("Unknown")]
	CocosKeelingIslandsAustralia = 47,
	[Description("Colombia")]
	[InternetDomainCode("CO")]
	Colombia = 48,
	[Description("Commonwealth of Independent States")]
	[InternetDomainCode("Unknown")]
	CommonwealthOfIndependentStates = 222,
	[Description("Comoros")]
	[InternetDomainCode("KM")]
	Comoros = 49,
	[Description("Congo, Republic of")]
	[InternetDomainCode("Unknown")]
	CongoRepublicOf = 50,
	[InternetDomainCode("Unknown")]
	[Description("Cook Islands (New Zealand)")]
	CookIslandsNewZealand = 51,
	[InternetDomainCode("Unknown")]
	[Description("Coral Sea Islands (Australia)")]
	CoralSeaIslandsAustralia = 52,
	[InternetDomainCode("CR")]
	[Description("Costa Rica")]
	CostaRica = 53,
	[InternetDomainCode("Unknown")]
	[Description("(Cote D'Ivoire (aka Ivory Coast)")]
	CoteDIvoireAkaIvoryCoast = 107,
	[Description("Croatia")]
	[InternetDomainCode("Unknown")]
	Croatia = 249,
	[Description("Cuba")]
	[InternetDomainCode("CU")]
	Cuba = 54,
	[Description("Cyprus")]
	[InternetDomainCode("CY")]
	Cyprus = 55,
	[Description("Czechoslovakia (separating into Czech Republic and Slovak Republic)")]
	[InternetDomainCode("Unknown")]
	CzechoslovakiaSeparatingIntoCzechRepublicAndSlovakRepublic = 56,
	[InternetDomainCode("Unknown")]
	[Description("Dahomey (aka Benin)")]
	DahomeyAkaBenin = 23,
	[InternetDomainCode("DK")]
	[Description("Denmark")]
	Denmark = 57,
	[InternetDomainCode("DJ")]
	[Description("Djibouti")]
	Djibouti = 58,
	[Description("Dominica")]
	[InternetDomainCode("DM")]
	Dominica = 59,
	[Description("Dominican Republic")]
	[InternetDomainCode("DO")]
	DominicanRepublic = 60,
	[Description("Ecuador")]
	[InternetDomainCode("EC")]
	Ecuador = 61,
	[Description("Egypt")]
	[InternetDomainCode("EG")]
	Egypt = 62,
	[Description("El Salvador")]
	[InternetDomainCode("SV")]
	ElSalvador = 63,
	[InternetDomainCode("GQ")]
	[Description("Equatorial Guinea")]
	EquatorialGuinea = 64,
	[Description("Estonia")]
	[InternetDomainCode("EE")]
	Estonia = 250,
	[Description("Ethiopia")]
	[InternetDomainCode("ET")]
	Ethiopia = 65,
	[Description("Europa Island (France)")]
	[InternetDomainCode("Unknown")]
	EuropaIslandFrance = 66,
	[Description("Falkland Islands (aka Islas Malvinas) (United Kingdom)")]
	[InternetDomainCode("Unknown")]
	FalklandIslandsAkaIslasMalvinasUnitedKingdom = 67,
	[Description("Faroe Islands (Denmark)")]
	[InternetDomainCode("Unknown")]
	FaroeIslandsDenmark = 68,
	[InternetDomainCode("FJ")]
	[Description("Fiji")]
	Fiji = 69,
	[Description("Finland")]
	[InternetDomainCode("FI")]
	Finland = 70,
	[Description("France")]
	[InternetDomainCode("FR")]
	France = 71,
	[Description("French Guiana (France)")]
	[InternetDomainCode("Unknown")]
	FrenchGuianaFrance = 72,
	[Description("French Polynesia (France)")]
	[InternetDomainCode("Unknown")]
	FrenchPolynesiaFrance = 73,
	[InternetDomainCode("Unknown")]
	[Description("French Southern and Antarctic Islands (France)")]
	FrenchSouthernAndAntarcticIslandsFrance = 74,
	[Description("Gabon")]
	[InternetDomainCode("GA")]
	Gabon = 75,
	[Description("Gambia, The")]
	[InternetDomainCode("Unknown")]
	GambiaThe = 76,
	[Description("Gaza Strip (Israel)")]
	[InternetDomainCode("Unknown")]
	GazaStripIsrael = 77,
	[Description("Georgia")]
	[InternetDomainCode("GE")]
	Georgia = 251,
	[Description("Germany")]
	[InternetDomainCode("DE")]
	Germany = 78,
	[Description("Ghana")]
	[InternetDomainCode("GH")]
	Ghana = 79,
	[Description("Gibraltar (United Kingdom)")]
	[InternetDomainCode("Unknown")]
	GibraltarUnitedKingdom = 80,
	[Description("Glorioso Islands (France)")]
	[InternetDomainCode("Unknown")]
	GloriosoIslandsFrance = 81,
	[Description("Greece")]
	[InternetDomainCode("GR")]
	Greece = 82,
	[Description("Greenland (Denmark)")]
	[InternetDomainCode("Unknown")]
	GreenlandDenmark = 83,
	[Description("Grenada")]
	[InternetDomainCode("GD")]
	Grenada = 84,
	[Description("Guadaloupe (France)")]
	[InternetDomainCode("Unknown")]
	GuadaloupeFrance = 85,
	[InternetDomainCode("Unknown")]
	[Description("Guam (United States)")]
	GuamUnitedStates = 86,
	[InternetDomainCode("GT")]
	[Description("Guatemala")]
	Guatemala = 87,
	[InternetDomainCode("Unknown")]
	[Description("Guernsey (United Kingdom)")]
	GuernseyUnitedKingdom = 88,
	[InternetDomainCode("GN")]
	[Description("Guinea")]
	Guinea = 89,
	[InternetDomainCode("Unknown")]
	[Description("Guinea- Bissau")]
	GuineaBissau = 90,
	[InternetDomainCode("GY")]
	[Description("Guyana")]
	Guyana = 91,
	[InternetDomainCode("HT")]
	[Description("Haiti")]
	Haiti = 92,
	[InternetDomainCode("Unknown")]
	[Description("Heard Island and McDonald Islands (Australia)")]
	HeardIslandAndMcDonaldIslandsAustralia = 93,
	[Description("Honduras")]
	[InternetDomainCode("HN")]
	Honduras = 94,
	[Description("Hong Kong (United Kingdom)")]
	[InternetDomainCode("Unknown")]
	HongKongUnitedKingdom = 95,
	[InternetDomainCode("Unknown")]
	[Description("Howland Island (United States)")]
	HowlandIslandUnitedStates = 96,
	[InternetDomainCode("HU")]
	[Description("Hungary")]
	Hungary = 97,
	[InternetDomainCode("IS")]
	[Description("Iceland")]
	Iceland = 98,
	[InternetDomainCode("IN")]
	[Description("India")]
	India = 99,
	[InternetDomainCode("ID")]
	[Description("Indonesia")]
	Indonesia = 100,
	[InternetDomainCode("IR")]
	[Description("Iran")]
	Iran = 101,
	[InternetDomainCode("IQ")]
	[Description("Iraq")]
	Iraq = 102,
	[Description("Ireland")]
	[InternetDomainCode("IE")]
	Ireland = 104,
	[Description("Israel")]
	[InternetDomainCode("IL")]
	Israel = 105,
	[Description("Italy")]
	[InternetDomainCode("IT")]
	Italy = 106,
	[Description("Ivory Coast (aka Cote D'Ivoire)")]
	[InternetDomainCode("Unknown")]
	IvoryCoastAkaCoteDIvoire = 107,
	[Description("Jamaica")]
	[InternetDomainCode("JM")]
	Jamaica = 108,
	[Description("Jan Mayen (Norway)")]
	[InternetDomainCode("Unknown")]
	JanMayenNorway = 109,
	[Description("Japan")]
	[InternetDomainCode("JP")]
	Japan = 110,
	[InternetDomainCode("Unknown")]
	[Description("Jarvis Island (United States)")]
	JarvisIslandUnitedStates = 111,
	[Description("Jersey (United Kingdom)")]
	[InternetDomainCode("Unknown")]
	JerseyUnitedKingdom = 112,
	[Description("Johnston Atoll (United States)")]
	[InternetDomainCode("Unknown")]
	JohnstonAtollUnitedStates = 113,
	[InternetDomainCode("JO")]
	[Description("Jordan")]
	Jordan = 114,
	[Description("Juan de Nova Island")]
	[InternetDomainCode("Unknown")]
	JuanDeNovaIsland = 115,
	[Description("Kazakhstan")]
	[InternetDomainCode("KZ")]
	Kazakhstan = 252,
	[Description("Kenya")]
	[InternetDomainCode("KE")]
	Kenya = 116,
	[Description("Kingman Reef (United States)")]
	[InternetDomainCode("Unknown")]
	KingmanReefUnitedStates = 117,
	[Description("Kiribati")]
	[InternetDomainCode("KI")]
	Kiribati = 118,
	[Description("Korea, Democratic People's Republic of (North)")]
	[InternetDomainCode("Unknown")]
	KoreaDemocraticPeopleSRepublicOfNorth = 119,
	[Description("Korea, Republic of (South)")]
	[InternetDomainCode("Unknown")]
	KoreaRepublicOfSouth = 120,
	[InternetDomainCode("KW")]
	[Description("Kuwait")]
	Kuwait = 121,
	[Description("Kyrgyzstan")]
	[InternetDomainCode("KG")]
	Kyrgyzstan = 253,
	[Description("Laos")]
	[InternetDomainCode("LA")]
	Laos = 122,
	[Description("Latvia")]
	[InternetDomainCode("LV")]
	Latvia = 254,
	[Description("Lebanon")]
	[InternetDomainCode("LB")]
	Lebanon = 123,
	[InternetDomainCode("LS")]
	[Description("Lesotho")]
	Lesotho = 124,
	[Description("Liberia")]
	[InternetDomainCode("LR")]
	Liberia = 125,
	[InternetDomainCode("LY")]
	[Description("Libya")]
	Libya = 126,
	[Description("Liechtenstein")]
	[InternetDomainCode("LI")]
	Liechtenstein = 127,
	[Description("Lithuania")]
	[InternetDomainCode("LT")]
	Lithuania = 255,
	[Description("Luxembourg")]
	[InternetDomainCode("LU")]
	Luxembourg = 128,
	[Description("Macau (Portugal)")]
	[InternetDomainCode("Unknown")]
	MacauPortugal = 130,
	[InternetDomainCode("MK")]
	[Description("Macedonia")]
	Macedonia = 256,
	[InternetDomainCode("MG")]
	[Description("Madagascar")]
	Madagascar = 129,
	[Description("Malawi")]
	[InternetDomainCode("MW")]
	Malawi = 131,
	[InternetDomainCode("MY")]
	[Description("Malaysia")]
	Malaysia = 132,
	[Description("Maldives")]
	[InternetDomainCode("MV")]
	Maldives = 133,
	[InternetDomainCode("ML")]
	[Description("Mali")]
	Mali = 134,
	[InternetDomainCode("MT")]
	[Description("Malta")]
	Malta = 135,
	[Description("Man, Isle of (United Kingdom)")]
	[InternetDomainCode("Unknown")]
	ManIsleOfUnitedKingdom = 136,
	[Description("Marshall Islands")]
	[InternetDomainCode("MH")]
	MarshallIslands = 137,
	[InternetDomainCode("Unknown")]
	[Description("Martinique (France)")]
	MartiniqueFrance = 138,
	[Description("Mauritania")]
	[InternetDomainCode("MR")]
	Mauritania = 139,
	[Description("Mauritius")]
	[InternetDomainCode("MU")]
	Mauritius = 140,
	[Description("Mayotte (France)")]
	[InternetDomainCode("Unknown")]
	MayotteFrance = 141,
	[InternetDomainCode("MX")]
	[Description("Mexico")]
	Mexico = 142,
	[Description("Micronesia, Federative States of")]
	[InternetDomainCode("Unknown")]
	MicronesiaFederativeStatesOf = 143,
	[Description("Midway Islands (United States)")]
	[InternetDomainCode("Unknown")]
	MidwayIslandsUnitedStates = 257,
	[Description("Moldova")]
	[InternetDomainCode("MD")]
	Moldova = 258,
	[Description("Monaco")]
	[InternetDomainCode("MC")]
	Monaco = 144,
	[Description("Mongolia")]
	[InternetDomainCode("MN")]
	Mongolia = 145,
	[Description("Montenegro")]
	[InternetDomainCode("Unknown")]
	Montenegro = 259,
	[Description("Montserrat (United Kingdom)")]
	[InternetDomainCode("Unknown")]
	MontserratUnitedKingdom = 146,
	[Description("Morocco")]
	[InternetDomainCode("MA")]
	Morocco = 147,
	[Description("Mozambique")]
	[InternetDomainCode("MZ")]
	Mozambique = 148,
	[Description("Myanmar (aka Burma)")]
	[InternetDomainCode("Unknown")]
	MyanmarAkaBurma = 35,
	[Description("Namibia (South West Africa)")]
	[InternetDomainCode("Unknown")]
	NamibiaSouthWestAfrica = 149,
	[Description("Nauru")]
	[InternetDomainCode("NR")]
	Nauru = 150,
	[Description("Navassa Island (United States)")]
	[InternetDomainCode("Unknown")]
	NavassaIslandUnitedStates = 151,
	[Description("Nepal")]
	[InternetDomainCode("NP")]
	Nepal = 152,
	[Description("Netherlands")]
	[InternetDomainCode("NL")]
	Netherlands = 153,
	[Description("Netherlands Antilles (Curacao, Bonaire, Saba, Sint Maarten Sint Eustatius)")]
	[InternetDomainCode("Unknown")]
	NetherlandsAntillesCuracaoBonaireSabaSintMaartenSintEustatius = 154,
	[Description("New Caledonia (France)")]
	[InternetDomainCode("Unknown")]
	NewCaledoniaFrance = 155,
	[InternetDomainCode("Unknown")]
	[Description("New Zealand")]
	NewZealand = 156,
	[Description("Nicaragua")]
	[InternetDomainCode("NI")]
	Nicaragua = 157,
	[InternetDomainCode("NE")]
	[Description("Niger")]
	Niger = 158,
	[InternetDomainCode("NG")]
	[Description("Nigeria")]
	Nigeria = 159,
	[InternetDomainCode("Unknown")]
	[Description("Niue (New Zealand)")]
	NiueNewZealand = 160,
	[InternetDomainCode("Unknown")]
	[Description("Norfolk Island (Australia)")]
	NorfolkIslandAustralia = 161,
	[Description("Northern Mariana Islands (United States)")]
	[InternetDomainCode("Unknown")]
	NorthernMarianaIslandsUnitedStates = 162,
	[Description("Norway")]
	[InternetDomainCode("NO")]
	Norway = 163,
	[Description("Oman")]
	[InternetDomainCode("OM")]
	Oman = 164,
	[Description("Pacific Islands, Trust Territory of the (Palau)")]
	[InternetDomainCode("Unknown")]
	PacificIslandsTrustTerritoryOfThePalau = 216,
	[Description("Pakistan")]
	[InternetDomainCode("PK")]
	Pakistan = 165,
	[Description("Palmyra Atoll (United States)")]
	[InternetDomainCode("Unknown")]
	PalmyraAtollUnitedStates = 166,
	[Description("Panama")]
	[InternetDomainCode("PA")]
	Panama = 168,
	[Description("Papua New Guinea")]
	[InternetDomainCode("PG")]
	PapuaNewGuinea = 169,
	[Description("Paracel Islands (International - Occupied by China, also claimed by Taiwan and Vietnam)")]
	[InternetDomainCode("Unknown")]
	ParacelIslandsInternationalOccupiedByChinaAlsoClaimedByTaiwanAndVietnam = 170,
	[Description("Paraguay")]
	[InternetDomainCode("PY")]
	Paraguay = 171,
	[InternetDomainCode("PE")]
	[Description("Peru")]
	Peru = 172,
	[InternetDomainCode("PH")]
	[Description("Philippines")]
	Philippines = 173,
	[InternetDomainCode("Unknown")]
	[Description("Pitcairn Islands (United Kingdom)")]
	PitcairnIslandsUnitedKingdom = 174,
	[InternetDomainCode("PL")]
	[Description("Poland")]
	Poland = 175,
	[Description("Portugal")]
	[InternetDomainCode("PT")]
	Portugal = 176,
	[InternetDomainCode("Unknown")]
	[Description("Puerto Rico (United States)")]
	PuertoRicoUnitedStates = 177,
	[InternetDomainCode("QA")]
	[Description("Qatar")]
	Qatar = 178,
	[InternetDomainCode("Unknown")]
	[Description("Reunion (France)")]
	ReunionFrance = 179,
	[Description("Romania")]
	[InternetDomainCode("RO")]
	Romania = 180,
	[Description("Russia")]
	[InternetDomainCode("Unknown")]
	Russia = 260,
	[Description("Rwanda")]
	[InternetDomainCode("RW")]
	Rwanda = 181,
	[Description("St. Helena (United Kingdom)")]
	[InternetDomainCode("Unknown")]
	StHelenaUnitedKingdom = 183,
	[Description("St. Lucia")]
	[InternetDomainCode("Unknown")]
	StLucia = 184,
	[InternetDomainCode("Unknown")]
	[Description("St. Vincent and the Grenadines")]
	StVincentAndTheGrenadines = 186,
	[InternetDomainCode("Unknown")]
	[Description("St. Kitts and Nevis")]
	StKittsAndNevis = 182,
	[InternetDomainCode("Unknown")]
	[Description("St. Pierre and Miquelon (France)")]
	StPierreAndMiquelonFrance = 185,
	[InternetDomainCode("SM")]
	[Description("San Marino")]
	SanMarino = 187,
	[InternetDomainCode("ST")]
	[Description("Sao Tome and Principe")]
	SaoTomeAndPrincipe = 188,
	[Description("Saudi Arabia")]
	[InternetDomainCode("SA")]
	SaudiArabia = 189,
	[Description("Senegal")]
	[InternetDomainCode("SN")]
	Senegal = 190,
	[Description("Serbia and Montenegro (Montenegro to separate)")]
	[InternetDomainCode("Unknown")]
	SerbiaAndMontenegroMontenegroToSeparate = 261,
	[Description("Seychelles")]
	[InternetDomainCode("SC")]
	Seychelles = 191,
	[InternetDomainCode("SL")]
	[Description("Sierra Leone")]
	SierraLeone = 192,
	[Description("Singapore")]
	[InternetDomainCode("SG")]
	Singapore = 193,
	[Description("Slovenia")]
	[InternetDomainCode("SI")]
	Slovenia = 262,
	[Description("Solomon Islands")]
	[InternetDomainCode("SB")]
	SolomonIslands = 194,
	[InternetDomainCode("SO")]
	[Description("Somalia")]
	Somalia = 195,
	[Description("South Africa")]
	[InternetDomainCode("ZA")]
	SouthAfrica = 197,
	[Description("South Georgia and the South Sandwich Islands (United Kingdom)")]
	[InternetDomainCode("Unknown")]
	SouthGeorgiaAndTheSouthSandwichIslandsUnitedKingdom = 196,
	[Description("Spain")]
	[InternetDomainCode("ES")]
	Spain = 198,
	[InternetDomainCode("Unknown")]
	[Description("Spratly Islands (International - parts occupied and claimed by China,Malaysia, Philippines, Taiwan, Vietnam)")]
	SpratlyIslandsInternationalPartsOccupiedAndClaimedByChinaMalaysiaPhilippinesTaiwanVietnam = 199,
	[Description("Sri Lanka")]
	[InternetDomainCode("LK")]
	SriLanka = 200,
	[Description("Sudan")]
	[InternetDomainCode("SD")]
	Sudan = 201,
	[Description("Suriname")]
	[InternetDomainCode("SR")]
	Suriname = 202,
	[InternetDomainCode("Unknown")]
	[Description("Svalbard (Norway)")]
	SvalbardNorway = 203,
	[Description("Swaziland")]
	[InternetDomainCode("SZ")]
	Swaziland = 204,
	[Description("Sweden")]
	[InternetDomainCode("SE")]
	Sweden = 205,
	[InternetDomainCode("CH")]
	[Description("Switzerland")]
	Switzerland = 206,
	[Description("Syria")]
	[InternetDomainCode("SY")]
	Syria = 207,
	[Description("Taiwan")]
	[InternetDomainCode("TW")]
	Taiwan = 208,
	[Description("Tajikistan")]
	[InternetDomainCode("TJ")]
	Tajikistan = 263,
	[Description("Tanzania")]
	[InternetDomainCode("TZ")]
	Tanzania = 209,
	[Description("Thailand")]
	[InternetDomainCode("TH")]
	Thailand = 210,
	[Description("Togo")]
	[InternetDomainCode("TG")]
	Togo = 211,
	[Description("Tokelau (New Zealand)")]
	[InternetDomainCode("Unknown")]
	TokelauNewZealand = 212,
	[InternetDomainCode("TO")]
	[Description("Tonga")]
	Tonga = 213,
	[InternetDomainCode("TT")]
	[Description("Trinidad and Tobago")]
	TrinidadAndTobago = 214,
	[Description("Tromelin Island (France)")]
	[InternetDomainCode("Unknown")]
	TromelinIslandFrance = 215,
	[Description("Tunisia")]
	[InternetDomainCode("TN")]
	Tunisia = 217,
	[InternetDomainCode("TR")]
	[Description("Turkey")]
	Turkey = 218,
	[Description("Turkmenistan")]
	[InternetDomainCode("TM")]
	Turkmenistan = 264,
	[InternetDomainCode("Unknown")]
	[Description("Turks and Caicos Islands (United Kingdom)")]
	TurksAndCaicosIslandsUnitedKingdom = 219,
	[InternetDomainCode("TV")]
	[Description("Tuvalu")]
	Tuvalu = 220,
	[Description("Uganda")]
	[InternetDomainCode("UG")]
	Uganda = 221,
	[InternetDomainCode("UA")]
	[Description("Ukraine")]
	Ukraine = 265,
	[InternetDomainCode("AE")]
	[Description("United Arab Emirates")]
	UnitedArabEmirates = 223,
	[Description("United Kingdom")]
	[InternetDomainCode("UK")]
	UnitedKingdom = 224,
	[InternetDomainCode("US")]
	[Description("United States")]
	UnitedStates = 225,
	[InternetDomainCode("Unknown")]
	[Description("Upper Volta (aka Burkina or Burkina Faso)")]
	UpperVoltaAkaBurkinaOrBurkinaFaso = 34,
	[InternetDomainCode("UY")]
	[Description("Uruguay")]
	Uruguay = 226,
	[Description("Uzbekistan")]
	[InternetDomainCode("UZ")]
	Uzbekistan = 266,
	[Description("Vanuatu")]
	[InternetDomainCode("VU")]
	Vanuatu = 227,
	[Description("Vatican City (Holy See)")]
	[InternetDomainCode("Unknown")]
	VaticanCityHolySee = 228,
	[InternetDomainCode("VE")]
	[Description("Venezuela")]
	Venezuela = 229,
	[InternetDomainCode("Unknown")]
	[Description("Vietnam")]
	Vietnam = 230,
	[Description("Virgin Islands (United States)")]
	[InternetDomainCode("Unknown")]
	VirginIslandsUnitedStates = 231,
	[InternetDomainCode("Unknown")]
	[Description("Wake Island (United States)")]
	WakeIslandUnitedStates = 232,
	[InternetDomainCode("Unknown")]
	[Description("Wallis and Futuna (France)")]
	WallisAndFutunaFrance = 233,
	[InternetDomainCode("Unknown")]
	[Description("West Bank (Israel)")]
	WestBankIsrael = 235,
	[Description("Western Sahara")]
	[InternetDomainCode("EH")]
	WesternSahara = 234,
	[Description("Western Samoa")]
	[InternetDomainCode("Unknown")]
	WesternSamoa = 236,
	[Description("Yemen")]
	[InternetDomainCode("YE")]
	Yemen = 237,
	[Description("Serbia and Montenegro")]
	[InternetDomainCode("CS")]
	SerbiaAndMontenegro = 240,
	[InternetDomainCode("Unknown")]
	[Description("Zaire")]
	Zaire = 241,
	[InternetDomainCode("ZM")]
	[Description("Zambia")]
	Zambia = 242,
	[InternetDomainCode("ZW")]
	[Description("Zimbabwe")]
	Zimbabwe = 243
}
