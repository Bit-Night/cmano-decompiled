using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.DistributedEmission;

[Serializable]
public enum ElectromagneticEmitters : ushort
{
	[Description("1RL138.")]
	_1RL138 = 10,
	[Description("1226 DECCA MIL.")]
	_1226DECCAMIL = 45,
	[Description("9GR400.")]
	_9GR400 = 80,
	[Description("9GR600.")]
	_9GR600 = 90,
	[Description("9LV 200 TA.")]
	_9LV200TA = 135,
	[Description("9LV 200 TV.")]
	_9LV200TV = 180,
	[Description("A310Z.")]
	A310Z = 225,
	[Description("A325A.")]
	A325A = 270,
	[Description("A346Z.")]
	A346Z = 315,
	[Description("A353B.")]
	A353B = 360,
	[Description("A372A.")]
	A372A = 405,
	[Description("A372B.")]
	A372B = 450,
	[Description("A372C.")]
	A372C = 495,
	[Description("A377A.")]
	A377A = 540,
	[Description("A377B.")]
	A377B = 585,
	[Description("A380Z.")]
	A380Z = 630,
	[Description("A381Z.")]
	A381Z = 675,
	[Description("A398Z.")]
	A398Z = 720,
	[Description("A403Z.")]
	A403Z = 765,
	[Description("A409A.")]
	A409A = 810,
	[Description("A418A.")]
	A418A = 855,
	[Description("A419Z.")]
	A419Z = 900,
	[Description("A429Z.")]
	A429Z = 945,
	[Description("A432Z.")]
	A432Z = 990,
	[Description("A434Z.")]
	A434Z = 1035,
	[Description("A401A.")]
	A401A = 1080,
	[Description("AA-12 Seeker.")]
	const_26 = 1095,
	[Description("Agave.")]
	Agave = 1100,
	[Description("AGRION 15.")]
	AGRION15 = 1125,
	[Description("AI MK 23.")]
	AIMK23 = 1170,
	[Description("AIDA II.")]
	AIDAII = 1215,
	[Description("Albatros MK2.")]
	const_31 = 1260,
	[Description("Box Spring.")]
	BoxSpring = 1280,
	[Description("Box Spring B.")]
	BoxSpringB = 1282,
	[Description("ANA SPS 502.")]
	const_34 = 1305,
	[Description("ANRITSU Electric AR-30A.")]
	const_35 = 1350,
	[Description("Antilope V.")]
	AntilopeV = 1395,
	[Description("AN/ALE-50.")]
	ANALE50 = 1400,
	[Description("AN/ALQ 99.")]
	ANALQ99 = 1440,
	[Description("AN/ALQ-100.")]
	ANALQ100 = 1485,
	[Description("AN/ALQ-101.")]
	ANALQ101 = 1530,
	[Description("AN/ALQ-119.")]
	ANALQ119 = 1575,
	[Description("AN/ALQ-122.")]
	ANALQ122 = 1585,
	[Description("AN/ALQ-126A.")]
	const_43 = 1620,
	[Description("AN/ALQ-131.")]
	ANALQ131 = 1626,
	[Description("AN/ALQ-135C/D.")]
	const_45 = 1628,
	[Description("AN/ALQ-144A(V)3.")]
	const_46 = 1630,
	[Description("AN/ALQ-153.")]
	ANALQ153 = 1632,
	[Description("AN/ALQ-155.")]
	ANALQ155 = 1634,
	[Description("AN/ALQ-161/A.")]
	const_49 = 1636,
	[Description("AN/ALQ-162.")]
	ANALQ162 = 1638,
	[Description("AN/ALQ-165.")]
	ANALQ165 = 1640,
	[Description("AN/ALQ-167.")]
	ANALQ167 = 1642,
	[Description("AN/ALQ-172(V)2.")]
	const_53 = 1644,
	[Description("AN/ALQ-176.")]
	ANALQ176 = 1646,
	[Description("AN/ALQ-184.")]
	ANALQ184 = 1648,
	[Description("AN/ALQ-188.")]
	ANALQ188 = 1650,
	[Description("AN/ALR-56.")]
	ANALR56 = 1652,
	[Description("AN/ALR-69.")]
	ANALR69 = 1654,
	[Description("AN/ALT-16A.")]
	ANALT16A = 1656,
	[Description("AN/ALT-28.")]
	ANALT28 = 1658,
	[Description("AN/ALT-32A.")]
	ANALT32A = 1660,
	[Description("AN/APD 10.")]
	ANAPD10 = 1665,
	[Description("AN/APG 53.")]
	ANAPG53 = 1710,
	[Description("AN/APG 59.")]
	ANAPG59 = 1755,
	[Description("AN/APG-63.")]
	ANAPG63 = 1800,
	[Description("AN/APG-63(V)1.")]
	const_66 = 1805,
	[Description("AN/APG-63(V)2.")]
	const_67 = 1807,
	[Description("AN/APG-63(V)3.")]
	const_68 = 1809,
	[Description("AN/APG 65.")]
	ANAPG65 = 1845,
	[Description("AN/APG-66.")]
	ANAPG66 = 1870,
	[Description("AN/APG 68.")]
	ANAPG68 = 1890,
	[Description("AN/APG 70.")]
	ANAPG70 = 1935,
	[Description("AN/APG-73.")]
	ANAPG73 = 1945,
	[Description("AN/APG-77.")]
	ANAPG77 = 1960,
	[Description("AN/APG-78.")]
	ANAPG78 = 1970,
	[Description("AN/APG-502.")]
	ANAPG502 = 1980,
	[Description("AN/APN-1.")]
	ANAPN1 = 2025,
	[Description("AN/APN-22.")]
	ANAPN22 = 2070,
	[Description("AN/APN 59.")]
	ANAPN59 = 2115,
	[Description("AN/APN-69.")]
	ANAPN69 = 2160,
	[Description("AN/APN-81.")]
	ANAPN81 = 2205,
	[Description("AN/APN-117.")]
	ANAPN117 = 2250,
	[Description("AN/APN-118.")]
	ANAPN118 = 2295,
	[Description("AN/APN-130.")]
	ANAPN130 = 2340,
	[Description("AN/APN-131.")]
	ANAPN131 = 2385,
	[Description("AN/APN-133.")]
	ANAPN133 = 2430,
	[Description("AN/APN-134.")]
	ANAPN134 = 2475,
	[Description("AN/APN-147.")]
	ANAPN147 = 2520,
	[Description("AN/APN-150.")]
	ANAPN150 = 2565,
	[Description("AN/APN-153.")]
	ANAPN153 = 2610,
	[Description("AN/APN 154.")]
	ANAPN154 = 2655,
	[Description("AN/APN-155.")]
	ANAPN155 = 2700,
	[Description("AN/APN-159.")]
	ANAPN159 = 2745,
	[Description("AN/APN-182.")]
	ANAPN182 = 2790,
	[Description("AN/APN-187.")]
	ANAPN187 = 2835,
	[Description("AN/APN-190.")]
	ANAPN190 = 2880,
	[Description("AN/APN 194.")]
	ANAPN194 = 2925,
	[Description("AN/APN-195.")]
	ANAPN195 = 2970,
	[Description("AN/APN-198.")]
	ANAPN198 = 3015,
	[Description("AN/APN-200.")]
	ANAPN200 = 3060,
	[Description("AN/APN 202.")]
	ANAPN202 = 3105,
	[Description("AN/APN-217.")]
	ANAPN217 = 3150,
	[Description("AN/APN-218.")]
	ANAPN218 = 3152,
	[Description("AN/APN-238.")]
	ANAPN238 = 3160,
	[Description("AN/APN-239.")]
	ANAPN239 = 3162,
	[Description("AN/APN-241.")]
	ANAPN241 = 3164,
	[Description("AN/APN-242.")]
	ANAPN242 = 3166,
	[Description("AN/APN-506.")]
	ANAPN506 = 3195,
	[Description("AN/APQ-72.")]
	ANAPQ72 = 3240,
	[Description("AN/APQ-99.")]
	ANAPQ99 = 3285,
	[Description("AN/APQ 100.")]
	ANAPQ100 = 3330,
	[Description("AN/APQ-102.")]
	ANAPQ102 = 3375,
	[Description("AN/APQ-109.")]
	ANAPQ109 = 3420,
	[Description("AN/APQ 113.")]
	ANAPQ113 = 3465,
	[Description("AN/APQ 120.")]
	ANAPQ120 = 3510,
	[Description("AN/APQ 126.")]
	ANAPQ126 = 3555,
	[Description("AN/APQ-128.")]
	ANAPQ128 = 3600,
	[Description("AN/APQ-129.")]
	ANAPQ129 = 3645,
	[Description("AN/APQ 148.")]
	ANAPQ148 = 3690,
	[Description("AN/APQ-153.")]
	ANAPQ153 = 3735,
	[Description("AN/APQ 159.")]
	ANAPQ159 = 3780,
	[Description("AN/APQ-164.")]
	ANAPQ164 = 3785,
	[Description("AN/APQ-166.")]
	ANAPQ166 = 3788,
	[Description("AN/APQ-181.")]
	ANAPQ181 = 3795,
	[Description("AN/APS-31.")]
	ANAPS31 = 3820,
	[Description("AN/APS-42.")]
	ANAPS42 = 3825,
	[Description("AN/APS 80.")]
	ANAPS80 = 3870,
	[Description("AN/APS-88.")]
	ANAPS88 = 3915,
	[Description("AN/APS 115.")]
	ANAPS115 = 3960,
	[Description("AN/APS 116.")]
	ANAPS116 = 4005,
	[Description("AN/APS-120.")]
	ANAPS120 = 4050,
	[Description("AN/APS 121.")]
	ANAPS121 = 4095,
	[Description("AN/APS 124.")]
	ANAPS124 = 4140,
	[Description("AN/APS 125.")]
	ANAPS125 = 4185,
	[Description("AN/APS-128.")]
	ANAPS128 = 4230,
	[Description("AN/APS 130.")]
	ANAPS130 = 4275,
	[Description("AN/APS 133.")]
	ANAPS133 = 4320,
	[Description("AN/APS-134.")]
	ANAPS134 = 4365,
	[Description("AN/APS 137.")]
	ANAPS137 = 4410,
	[Description("AN/APS-138.")]
	ANAPS138 = 4455,
	[Description("AN/APS-143 (V) 1.")]
	const_141 = 4465,
	[Description("AN/APW 22.")]
	ANAPW22 = 4500,
	[Description("AN/APW 23.")]
	ANAPW23 = 4545,
	[Description("AN/APX-6.")]
	ANAPX6 = 4590,
	[Description("AN/APX 7.")]
	ANAPX7 = 4635,
	[Description("AN/APX 39.")]
	ANAPX39 = 4680,
	[Description("AN/APX-72.")]
	ANAPX72 = 4725,
	[Description("AN/APX 76.")]
	ANAPX76 = 4770,
	[Description("AN/APX 78.")]
	ANAPX78 = 4815,
	[Description("AN/APX 101.")]
	ANAPX101 = 4860,
	[Description("AN/APX-113 AIFF.")]
	ANAPX113AIFF = 4870,
	[Description("AN/APY-1.")]
	ANAPY1 = 4900,
	[Description("AN/APY 2.")]
	ANAPY2 = 4905,
	[Description("AN/APY 3.")]
	ANAPY3 = 4950,
	[Description("LYNX(tm).")]
	LYNXTm = 4953,
	[Description("AN/ARN 21.")]
	ANARN21 = 4995,
	[Description("AN/ARN 52.")]
	ANARN52 = 5040,
	[Description("AN/ARN 84.")]
	ANARN84 = 5085,
	[Description("AN/ARN 118.")]
	ANARN118 = 5130,
	[Description("AN/ARW 73.")]
	ANARW73 = 5175,
	[Description("AN/ASB 1.")]
	ANASB1 = 5220,
	[Description("AN/ASG 21.")]
	ANASG21 = 5265,
	[Description("AN/ASQ-108.")]
	ANASQ108 = 5280,
	[Description("AN/AWG 9.")]
	ANAWG9 = 5310,
	[Description("AN/BPS-9.")]
	ANBPS9 = 5355,
	[Description("AN/BPS 15.")]
	ANBPS15 = 5400,
	[Description("AN/BPS-16.")]
	ANBPS16 = 5405,
	[Description("AN/CRM-30.")]
	ANCRM30 = 5420,
	[Description("AN/DPW-23.")]
	ANDPW23 = 5430,
	[Description("AN/DSQ 26 Phoenix MH.")]
	ANDSQ26PhoenixMH = 5445,
	[Description("AN/DSQ 28 Harpoon MH.")]
	ANDSQ28HarpoonMH = 5490,
	[Description("AN/FPN-40.")]
	ANFPN40 = 5495,
	[Description("AN/FPN-62.")]
	ANFPN62 = 5500,
	[Description("AN/FPS-16.")]
	ANFPS16 = 5505,
	[Description("AN/FPS-18.")]
	ANFPS18 = 5507,
	[Description("AN/FPS-89.")]
	ANFPS89 = 5508,
	[Description("AN/FPS-117.")]
	ANFPS117 = 5510,
	[Description("AN/FPS-20R.")]
	ANFPS20R = 5515,
	[Description("AN/FPS-77.")]
	ANFPS77 = 5520,
	[Description("AN/FPS-103.")]
	ANFPS103 = 5525,
	[Description("AN/GPN-12.")]
	ANGPN12 = 5527,
	[Description("AN/GPX-6.")]
	ANGPX6 = 5530,
	[Description("AN/GPX 8.")]
	ANGPX8 = 5535,
	[Description("AN/GRN-12.")]
	ANGRN12 = 5537,
	[Description("AN/MPQ-10.")]
	ANMPQ10 = 5540,
	[Description("AN/MPQ-33/39/46/57/61 (HPIR) ILL.")]
	ANMPQ3339465761HPIRILL = 5545,
	[Description("AN/MPQ-34/48/55/62 (CWAR) TA.")]
	const_187 = 5550,
	[Description("AN/MPQ-49.")]
	ANMPQ49 = 5551,
	[Description("AN/MPQ-35/50 (PAR) TA.")]
	ANMPQ3550PARTA = 5555,
	[Description("AN/MPQ-37/51 (ROR) TT.")]
	ANMPQ3751RORTT = 5560,
	[Description("AN/MPQ-53.")]
	ANMPQ53 = 5570,
	[Description("AN/MPQ-63.")]
	ANMPQ63 = 5571,
	[Description("AN/MPQ-64.")]
	ANMPQ64 = 5575,
	[Description("AN/SPG-34.")]
	ANSPG34 = 5580,
	[Description("AN/SPG 50.")]
	ANSPG50 = 5625,
	[Description("AN/SPG 51.")]
	ANSPG51 = 5670,
	[Description("AN/SPG-51 CWI TI.")]
	ANSPG51CWITI = 5715,
	[Description("AN/SPG-51 FC.")]
	const_198 = 5760,
	[Description("AN/SPG 52.")]
	ANSPG52 = 5805,
	[Description("AN/SPG-53.")]
	ANSPG53 = 5850,
	[Description("AN/SPG 55B.")]
	ANSPG55B = 5895,
	[Description("AN/SPG 60.")]
	ANSPG60 = 5940,
	[Description("AN/SPG 62.")]
	ANSPG62 = 5985,
	[Description("AN/SPN 35.")]
	ANSPN35 = 6030,
	[Description("AN/SPN 43.")]
	ANSPN43 = 6075,
	[Description("AN/SPQ-2.")]
	ANSPQ2 = 6120,
	[Description("AN/SPQ 9.")]
	ANSPQ9 = 6165,
	[Description("AN/SPS-4.")]
	ANSPS4 = 6210,
	[Description("AN/SPS-5.")]
	ANSPS5 = 6255,
	[Description("AN/SPS-5C.")]
	ANSPS5C = 6300,
	[Description("AN/SPS-6.")]
	ANSPS6 = 6345,
	[Description("AN/SPS 10.")]
	ANSPS10 = 6390,
	[Description("AN/SPS 21.")]
	ANSPS21 = 6435,
	[Description("AN/SPS-28.")]
	ANSPS28 = 6480,
	[Description("AN/SPS-37.")]
	ANSPS37 = 6525,
	[Description("AN/SPS-39A.")]
	ANSPS39A = 6570,
	[Description("AN/SPS 40.")]
	ANSPS40 = 6615,
	[Description("AN/SPS-41.")]
	ANSPS41 = 6660,
	[Description("AN/SPS-48.")]
	ANSPS48 = 6705,
	[Description("AN/SPS-48C.")]
	ANSPS48C = 6750,
	[Description("AN/SPS-48E.")]
	ANSPS48E = 6752,
	[Description("AN/SPS-49.")]
	ANSPS49 = 6795,
	[Description("AN/SPS-49(V)1.")]
	const_223 = 6796,
	[Description("AN/SPS-49(V)2.")]
	const_224 = 6797,
	[Description("AN/SPS-49(V)3.")]
	const_225 = 6798,
	[Description("AN/SPS-49(V)4.")]
	const_226 = 6799,
	[Description("AN/SPS-49(V)5.")]
	const_227 = 6800,
	[Description("AN/SPS-49(V)6.")]
	const_228 = 6801,
	[Description("AN/SPS-49(V)7.")]
	const_229 = 6802,
	[Description("AN/SPS-49(V)8.")]
	const_230 = 6803,
	[Description("AN/SPS-49A(V)1.")]
	const_231 = 6804,
	[Description("AN/SPS 52.")]
	ANSPS52 = 6840,
	[Description("AN/SPS 53.")]
	ANSPS53 = 6885,
	[Description("AN/SPS 55.")]
	ANSPS55 = 6930,
	[Description("AN/SPS-55 SS.")]
	const_235 = 6975,
	[Description("AN/SPS-58.")]
	ANSPS58 = 7020,
	[Description("AN/SPS 59.")]
	ANSPS59 = 7065,
	[Description("AN/SPS 64.")]
	ANSPS64 = 7110,
	[Description("AN/SPS 65.")]
	ANSPS65 = 7155,
	[Description("AN/SPS 67.")]
	ANSPS67 = 7200,
	[Description("AN/SPY-1.")]
	ANSPY1 = 7245,
	[Description("AN/SPY-1A.")]
	ANSPY1A = 7250,
	[Description("AN/SPY-1B.")]
	ANSPY1B = 7252,
	[Description("AN/SPY-1B(V).")]
	ANSPY1BV = 7253,
	[Description("AN/SPY-1D.")]
	ANSPY1D = 7260,
	[Description("AN/SPY-1D(V).")]
	ANSPY1DV = 7261,
	[Description("AN/SPY-1F.")]
	ANSPY1F = 7265,
	[Description("AN/TPN-17.")]
	ANTPN17 = 7270,
	[Description("AN/TPN-24.")]
	ANTPN24 = 7275,
	[Description("AN/TPQ-18.")]
	ANTPQ18 = 7280,
	[Description("AN/TPQ-36.")]
	ANTPQ36 = 7295,
	[Description("AN/TPQ-37.")]
	ANTPQ37 = 7300,
	[Description("AN/TPQ-38 (V8).")]
	const_253 = 7301,
	[Description("AN/TPQ-47.")]
	ANTPQ47 = 7303,
	[Description("AN/TPS-43.")]
	ANTPS43 = 7305,
	[Description("AN/TPS-43E.")]
	ANTPS43E = 7310,
	[Description("AN/TPS-59.")]
	ANTPS59 = 7315,
	[Description("AN/TPS-63.")]
	ANTPS63 = 7320,
	[Description("AN/TPS-70 (V) 1.")]
	const_259 = 7322,
	[Description("AN/TPS-75.")]
	ANTPS75 = 7325,
	[Description("AN/TPX-46(V)7.")]
	const_261 = 7330,
	[Description("AN/ULQ-6A.")]
	ANULQ6A = 7335,
	[Description("AN/UPN 25.")]
	ANUPN25 = 7380,
	[Description("AN/UPS 1.")]
	ANUPS1 = 7425,
	[Description("AN/UPS-2.")]
	ANUPS2 = 7426,
	[Description("AN/UPX 1.")]
	ANUPX1 = 7470,
	[Description("AN/UPX 5.")]
	ANUPX5 = 7515,
	[Description("AN/UPX 11.")]
	ANUPX11 = 7560,
	[Description("AN/UPX 12.")]
	ANUPX12 = 7605,
	[Description("AN/UPX 17.")]
	ANUPX17 = 7650,
	[Description("AN/UPX 23.")]
	ANUPX23 = 7695,
	[Description("AN/VPS 2.")]
	ANVPS2 = 7740,
	[Description("Apelco AD 7 7.")]
	const_273 = 7785,
	[Description("APG 71.")]
	APG71 = 7830,
	[Description("APN 148.")]
	APN148 = 7875,
	[Description("APN 227.")]
	APN227 = 7920,
	[Description("APS 504 V3.")]
	APS504V3 = 8100,
	[Description("AR 3D.")]
	AR3D = 8105,
	[Description("Plessey AR-5.")]
	const_279 = 8112,
	[Description("AR 320.")]
	AR320 = 8115,
	[Description("AR 327.")]
	AR327 = 8120,
	[Description("AR M31.")]
	ARM31 = 8145,
	[Description("ARI 5954.")]
	ARI5954 = 8190,
	[Description("ARI 5955.")]
	ARI5955 = 8235,
	[Description("ARI 5979.")]
	ARI5979 = 8280,
	[Description("ARINC 564 BNDX/KING RDR 1E.")]
	ARINC564BNDXKINGRDR1E = 8325,
	[Description("ARINC 700 BNDX/KING RDR 1E.")]
	ARINC700BNDXKINGRDR1E = 8370,
	[Description("ARK-1.")]
	ARK1 = 8375,
	[Description("ARSR-3.")]
	ARSR3 = 8380,
	[Description("ARSR-18.")]
	ARSR18 = 8390,
	[Description("AS 2 Kipper.")]
	const_291 = 8415,
	[Description("AS 2 Kipper MH.")]
	const_292 = 8460,
	[Description("AS 4 Kitchen.")]
	const_293 = 8505,
	[Description("AS 4 Kitchen MH.")]
	AS4KitchenMH = 8550,
	[Description("AS 5 Kelt MH.")]
	const_295 = 8595,
	[Description("AS 6 Kingfish MH.")]
	AS6KingfishMH = 8640,
	[Description("AS 7 Kerry.")]
	AS7Kerry = 8685,
	[Description("AS 7 Kerry MG.")]
	const_298 = 8730,
	[Description("AS 15 KENT altimeter.")]
	AS15KENTAltimeter = 8735,
	[Description("Aspide AAM/SAM ILL.")]
	AspideAAMSAMILL = 8760,
	[Description("ASR-4.")]
	ASR4 = 8772,
	[Description("ASR O.")]
	ASRO = 8775,
	[Description("ASR-5.")]
	ASR5 = 8780,
	[Description("ASR-7.")]
	ASR7 = 8782,
	[Description("ASR-8.")]
	ASR8 = 8785,
	[Description("ASR-9.")]
	ASR9 = 8790,
	[Description("Raytheon ASR-10SS.")]
	RaytheonASR10SS = 8812,
	[Description("AT 2 Swatter MG.")]
	AT2SwatterMG = 8820,
	[Description("ATCR-33.")]
	ATCR33 = 8840,
	[Description("ATCR 33 K/M.")]
	ATCR33KM = 8845,
	[Description("Atlas Elektronk TRS N.")]
	const_311 = 8865,
	[Description("ATLAS-9740 VTS.")]
	ATLAS9740VTS = 8870,
	[Description("AVG 65.")]
	AVG65 = 8910,
	[Description("AVH 7.")]
	AVH7 = 8955,
	[Description("AVQ 20.")]
	AVQ20 = 9000,
	[Description("AVQ30X.")]
	AVQ30X = 9045,
	[Description("AVQ-50 (RCA).")]
	AVQ50RCA = 9075,
	[Description("AVQ 70.")]
	AVQ70 = 9090,
	[Description("AWS 5.")]
	AWS5 = 9135,
	[Description("AWS 6.")]
	AWS6 = 9180,
	[Description("B597Z.")]
	B597Z = 9200,
	[Description("B636Z.")]
	B636Z = 9205,
	[Description("Back Net A B.")]
	BackNetAB = 9225,
	[Description("Back Trap.")]
	BackTrap = 9270,
	[Description("BALTYK.")]
	BALTYK = 9310,
	[Description("Ball End.")]
	BallEnd = 9315,
	[Description("Ball Gun.")]
	BallGun = 9360,
	[Description("Band Stand.")]
	BandStand = 9405,
	[Description("Bar Lock.")]
	BarLock = 9450,
	[Description("Bass Tilt.")]
	BassTilt = 9495,
	[Description("Beacon.")]
	Beacon = 9540,
	[Description("Bean Sticks.")]
	BeanSticks = 9585,
	[Description("Bee Hind.")]
	BeeHind = 9630,
	[Description("Bell Crown A.")]
	BellCrownA = 9640,
	[Description("Bell Crown B.")]
	BellCrownB = 9642,
	[Description("BIG BACK.")]
	BIGBACK = 9645,
	[Description("Big Bird.")]
	BigBird = 9660,
	[Description("Big Bulge.")]
	BigBulge = 9675,
	[Description("Big Bulge A.")]
	BigBulgeA = 9720,
	[Description("Big Bulge B.")]
	BigBulgeB = 9765,
	[Description("Big Fred.")]
	BigFred = 9780,
	[Description("Big Mesh.")]
	BigMesh = 9810,
	[Description("Big Net.")]
	BigNet = 9855,
	[Description("Bill Board.")]
	BillBoard = 9885,
	[Description("Bill Fold.")]
	BillFold = 9900,
	[Description("Blowpipe MG.")]
	BlowpipeMG = 9905,
	[Description("Sea Harrier FRS Mk 1/5.")]
	SeaHarrierFRSMk15 = 9930,
	[Description("Sea Harrier F/A Mk 2.")]
	SeaHarrierFAMk2 = 9935,
	[Description("Blue Silk.")]
	BlueSilk = 9945,
	[Description("Blue Parrot.")]
	BlueParrot = 9990,
	[Description("Blue Orchid.")]
	BlueOrchid = 10035,
	[Description("Boat Sail.")]
	BoatSail = 10080,
	[Description("Bofors Electronic 9LV 331.")]
	BoforsElectronic9LV331 = 10125,
	[Description("Bofors Ericsson Sea Giraffe 50 HC.")]
	BoforsEricssonSeaGiraffe50HC = 10170,
	[Description("Bowl Mesh.")]
	BowlMesh = 10215,
	[Description("Box Brick.")]
	BoxBrick = 10260,
	[Description("Box Tail.")]
	BoxTail = 10305,
	[Description("BPS 11A.")]
	BPS11A = 10350,
	[Description("BPS 14.")]
	BPS14 = 10395,
	[Description("BPS 15A.")]
	BPS15A = 10440,
	[Description("BR-15 Tokyo KEIKI.")]
	BR15TokyoKEIKI = 10485,
	[Description("BRIDGEMASTE.")]
	BRIDGEMASTE = 10510,
	[Description("Bread Bin.")]
	BreadBin = 10530,
	[Description("BT 271.")]
	BT271 = 10575,
	[Description("BX 732.")]
	BX732 = 10620,
	[Description("Buzz Stand.")]
	BuzzStand = 10665,
	[Description("C 5A Multi Mode Radar.")]
	C5AMultiModeRadar = 10710,
	[Description("Caiman.")]
	Caiman = 10755,
	[Description("Cake Stand.")]
	CakeStand = 10800,
	[Description("Calypso C61.")]
	const_370 = 10845,
	[Description("Calypso Ii.")]
	CalypsoIi = 10890,
	[Description("Cardion Coastal.")]
	CardionCoastal = 10895,
	[Description("Castor Ii.")]
	CastorIi = 10935,
	[Description("Castor 2J TT (Crotale NG).")]
	const_374 = 10940,
	[Description("Cat House.")]
	CatHouse = 10980,
	[Description("CDR-431.")]
	CDR431 = 10985,
	[Description("Chair Back TT.")]
	ChairBackTT = 11000,
	[Description("Chair Back ILL.")]
	ChairBackILL = 11010,
	[Description("Cheese Brick.")]
	CheeseBrick = 11025,
	[Description("Clam Pipe.")]
	ClamPipe = 11070,
	[Description("Clamshell.")]
	Clamshell = 11115,
	[Description("Collins WXR-700X.")]
	CollinsWXR700X = 11160,
	[Description("Collins DN 101.")]
	CollinsDN101 = 11205,
	[Description("Contraves Sea Hunter MK 4.")]
	ContravesSeaHunterMK4 = 11250,
	[Description("Corn Can.")]
	CornCan = 11260,
	[Description("CR-105 RMCA.")]
	const_386 = 11270,
	[Description("Cross Bird.")]
	CrossBird = 11295,
	[Description("Cross Dome.")]
	CrossDome = 11340,
	[Description("Cross Legs.")]
	CrossLegs = 11385,
	[Description("Cross Out.")]
	CrossOut = 11430,
	[Description("Cross Slot.")]
	CrossSlot = 11475,
	[Description("Cross Sword.")]
	CrossSword = 11520,
	[Description("Cross Up.")]
	CrossUp = 11565,
	[Description("Cross Sword FC.")]
	CrossSwordFC = 11610,
	[Description("THD-5000.")]
	THD5000 = 11655,
	[Description("Griffon.")]
	Griffon = 11660,
	[Description("Crotale TT.")]
	CrotaleTT = 11665,
	[Description("Crotale MGMissile System.")]
	CrotaleMGMissileSystem = 11700,
	[Description("CSS C 3C CAS 1M1 M2 MH.")]
	CSSC3CCAS1M1M2MH = 11745,
	[Description("CSS C 2B HY 1A MH.")]
	CSSC2BHY1AMH = 11790,
	[Description("CWS 2.")]
	CWS2 = 11835,
	[Description("Cylinder Head.")]
	CylinderHead = 11880,
	[Description("Cyrano II.")]
	CyranoII = 11925,
	[Description("Cyrano IV.")]
	CyranoIV = 11970,
	[Description("Cyrano IV-M.")]
	const_405 = 11975,
	[Description("DA-01/00.")]
	DA0100 = 12010,
	[Description("DA 05 00.")]
	DA0500 = 12015,
	[Description("Dawn.")]
	Dawn = 12060,
	[Description("Dead Duck.")]
	DeadDuck = 12105,
	[Description("DECCA-20 V90/9.")]
	const_410 = 12110,
	[Description("DECCA-20 V90S.")]
	const_411 = 12111,
	[Description("DECCA 45.")]
	DECCA45 = 12150,
	[Description("DECCA 50.")]
	DECCA50 = 12195,
	[Description("DECCA 110.")]
	DECCA110 = 12240,
	[Description("DECCA 170.")]
	DECCA170 = 12285,
	[Description("DECCA HF 2.")]
	DECCAHF2 = 12292,
	[Description("DECCA 202.")]
	DECCA202 = 12330,
	[Description("DECCA D202.")]
	const_418 = 12375,
	[Description("DECCA 303.")]
	DECCA303 = 12420,
	[Description("DECCA 535.")]
	DECCA535 = 12430,
	[Description("DECCA 626.")]
	DECCA626 = 12465,
	[Description("DECCA 629.")]
	DECCA629 = 12510,
	[Description("DECCA 914.")]
	DECCA914 = 12555,
	[Description("DECCA 916.")]
	DECCA916 = 12600,
	[Description("DECCA 926.")]
	DECCA926 = 12610,
	[Description("DECCA 1226 Commercial.")]
	const_426 = 12645,
	[Description("DECCA 1626.")]
	const_427 = 12690,
	[Description("DECCA 2459.")]
	const_428 = 12735,
	[Description("DECCA AWS 1.")]
	const_429 = 12780,
	[Description("DECCA AWS 2.")]
	const_430 = 12782,
	[Description("DECCA AWS 4.")]
	const_431 = 12785,
	[Description("DECCA AWS-4 (2).")]
	const_432 = 12787,
	[Description("DECCA MAR.")]
	DECCAMAR = 12800,
	[Description("DECCA RM 326.")]
	const_434 = 12805,
	[Description("DECCA RM 416.")]
	const_435 = 12825,
	[Description("DECCA RM 914.")]
	const_436 = 12870,
	[Description("DECCA RM 1690.")]
	const_437 = 12915,
	[Description("DECCA Super 101 MK 3.")]
	DECCASuper101MK3 = 12960,
	[Description("DISS 1.")]
	DISS1 = 13005,
	[Description("DN 181.")]
	DN181 = 13050,
	[Description("BLINDFIRE FSC TT.")]
	BLINDFIREFSCTT = 13055,
	[Description("Dog Ear.")]
	DogEar = 13095,
	[Description("Dog House.")]
	DogHouse = 13140,
	[Description("Don 2.")]
	Don2 = 13185,
	[Description("Don A/B/2/Kay.")]
	const_445 = 13230,
	[Description("Donets.")]
	Donets = 13275,
	[Description("Down Beat.")]
	DownBeat = 13320,
	[Description("DRAA 2A.")]
	DRAA2A = 13365,
	[Description("DRAA 2B.")]
	DRAA2B = 13410,
	[Description("DRAC 39.")]
	DRAC39 = 13455,
	[Description("DRBC 30B.")]
	DRBC30B = 13500,
	[Description("DRBC 31A.")]
	DRBC31A = 13545,
	[Description("DRBC 32A.")]
	DRBC32A = 13590,
	[Description("DRBC 32D.")]
	DRBC32D = 13635,
	[Description("DRBC 33A.")]
	DRBC33A = 13680,
	[Description("DRBI 10.")]
	DRBI10 = 13725,
	[Description("DRBI 23.")]
	DRBI23 = 13770,
	[Description("DRBJ 11B.")]
	DRBJ11B = 13815,
	[Description("DRBN 30.")]
	DRBN30 = 13860,
	[Description("DRBN 32.")]
	DRBN32 = 13905,
	[Description("DRBR 51.")]
	DRBR51 = 13950,
	[Description("DRBV 20B.")]
	DRBV20B = 13995,
	[Description("DRBV 22.")]
	DRBV22 = 14040,
	[Description("DRBV 26C.")]
	DRBV26C = 14085,
	[Description("DRBV 30.")]
	DRBV30 = 14130,
	[Description("DRBV 50.")]
	DRBV50 = 14175,
	[Description("DRBV 51.")]
	DRBV51 = 14220,
	[Description("DRBV 51A.")]
	DRBV51A = 14265,
	[Description("DRBV 51B.")]
	DRBV51B = 14310,
	[Description("DRBV 51C.")]
	DRBV51C = 14355,
	[Description("Drop Kick.")]
	DropKick = 14400,
	[Description("DRUA 31.")]
	DRUA31 = 14445,
	[Description("Drum Tilt.")]
	DrumTilt = 14490,
	[Description("Drum Tilt A.")]
	DrumTiltA = 14535,
	[Description("Drum Tilt B.")]
	DrumTiltB = 14545,
	[Description("Dumbo.")]
	Dumbo = 14580,
	[Description("ECR-90.")]
	ECR90 = 14600,
	[Description("Egg Cup A/B.")]
	EggCupAB = 14625,
	[Description("EKCO 190.")]
	EKCO190 = 14670,
	[Description("EL M 2001B.")]
	ELM2001B = 14715,
	[Description("EL M 2207.")]
	ELM2207 = 14760,
	[Description("EL/M 2216(V).")]
	ELM2216V = 14770,
	[Description("ELTA EL/M 2221 GM STGR.")]
	ELTAELM2221GMSTGR = 14805,
	[Description("ELTA SIS.")]
	ELTASIS = 14810,
	[Description("EMD 2900.")]
	EMD2900 = 14850,
	[Description("End Tray.")]
	EndTray = 14895,
	[Description("Exocet 1.")]
	Exocet1 = 14940,
	[Description("Exocet 1 MH.")]
	const_488 = 14985,
	[Description("Exocet 2.")]
	Exocet2 = 15030,
	[Description("Eye Bowl.")]
	EyeBowl = 15075,
	[Description("Eye Shield.")]
	EyeShield = 15120,
	[Description("F332Z.")]
	F332Z = 15140,
	[Description("FALCON.")]
	FALCON = 15160,
	[Description("Fan Song A.")]
	FanSongA = 15165,
	[Description("Fan Song B/F TA.")]
	const_495 = 15200,
	[Description("Fan Song B/F TT.")]
	const_496 = 15210,
	[Description("Fan Song C/E TA.")]
	const_497 = 15220,
	[Description("Fan Song C/E TT.")]
	const_498 = 15230,
	[Description("Fan Song C/E MG.")]
	const_499 = 15240,
	[Description("Fan Song B/FF MG.")]
	FanSongBFFMG = 15255,
	[Description("Fan Tail.")]
	FanTail = 15300,
	[Description("FCR-1401.")]
	FCR1401 = 15310,
	[Description("Fin Curve.")]
	FinCurve = 15345,
	[Description("Fire Can.")]
	FireCan = 15390,
	[Description("Fire Dish.")]
	FireDish = 15435,
	[Description("Fire Dome TA.")]
	FireDomeTA = 15470,
	[Description("Fire Dome TT.")]
	FireDomeTT = 15475,
	[Description("Fire Dome TI.")]
	FireDomeTI = 15480,
	[Description("Fire Iron.")]
	FireIron = 15525,
	[Description("Fire Wheel.")]
	FireWheel = 15570,
	[Description("Fish Bowl.")]
	FishBowl = 15615,
	[Description("Flap Lid.")]
	FlapLid = 15660,
	[Description("Flap Truck.")]
	FlapTruck = 15705,
	[Description("Flap Wheel.")]
	FlapWheel = 15750,
	[Description("Flash Dance.")]
	FlashDance = 15795,
	[Description("Flat Face A B C D.")]
	FlatFaceABCD = 15840,
	[Description("Flat Screen.")]
	FlatScreen = 15885,
	[Description("Flat Spin.")]
	FlatSpin = 15930,
	[Description("Flat Twin.")]
	FlatTwin = 15975,
	[Description("Fledermaus.")]
	Fledermaus = 16020,
	[Description("FLYCATCHER.")]
	FLYCATCHER = 16030,
	[Description("Fly Screen.")]
	FlyScreen = 16065,
	[Description("Fly Screen A&amp;B.")]
	FlyScreenAB = 16110,
	[Description("Fly Trap B.")]
	FlyTrapB = 16155,
	[Description("Fog Lamp MG.")]
	FogLampMG = 16200,
	[Description("Fog Lamp TT.")]
	FogLampTT = 16245,
	[Description("Foil Two.")]
	FoilTwo = 16290,
	[Description("Fox Hunter.")]
	FoxHunter = 16335,
	[Description("FOX FIREFox Fire AL.")]
	FOXFIREFoxFireAL = 16380,
	[Description("FOX FIRE ILL.")]
	FOXFIREILL = 16390,
	[Description("FR-151A.")]
	FR151A = 16400,
	[Description("FR-1505 DA.")]
	FR1505DA = 16410,
	[Description("FR-2000.")]
	FR2000 = 16420,
	[Description("FR-2855W.")]
	FR2855W = 16421,
	[Description("Front Dome.")]
	FrontDome = 16425,
	[Description("Front Door.")]
	FrontDoor = 16470,
	[Description("Front Piece.")]
	FrontPiece = 16515,
	[Description("Furuno.")]
	Furuno = 16560,
	[Description("Furuno 1721.")]
	const_539 = 16561,
	[Description("Furuno 701.")]
	const_540 = 16605,
	[Description("Furuno 711 2.")]
	const_541 = 16650,
	[Description("Furuno 2400.")]
	const_542 = 16695,
	[Description("GA 01 00.")]
	GA0100 = 16740,
	[Description("Gage.")]
	Gage = 16785,
	[Description("Garpin.")]
	Garpin = 16830,
	[Description("GEM BX 132.")]
	GEMBX132 = 16875,
	[Description("Gepard TA.")]
	GepardTA = 16880,
	[Description("Gepard TT.")]
	GepardTT = 16884,
	[Description("GERAN-F.")]
	GERANF = 16888,
	[Description("GIRAFFE.")]
	GIRAFFE = 16900,
	[Description("Gin Sling TA.")]
	GinSlingTA = 16915,
	[Description("Gin Sling TT.")]
	GinSlingTT = 16920,
	[Description("Gin Sling MG.")]
	GinSlingMG = 16925,
	[Description("GPN-22.")]
	GPN22 = 16945,
	[Description("GRN-9.")]
	GRN9 = 16950,
	[Description("Green Stain.")]
	GreenStain = 16965,
	[Description("Grid Bow.")]
	GridBow = 17010,
	[Description("GRILL PAN TT.")]
	GRILLPANTT = 17025,
	[Description("Guardsman.")]
	Guardsman = 17055,
	[Description("GUN DISH (ZSU-23/4).")]
	GUNDISHZSU234 = 17070,
	[Description("Hair Net.")]
	HairNet = 17100,
	[Description("Half Plate A.")]
	HalfPlateA = 17145,
	[Description("Half Plate B.")]
	HalfPlateB = 17190,
	[Description("HARD.")]
	HARD = 17220,
	[Description("Hawk Screech.")]
	HawkScreech = 17235,
	[Description("Head Light A.")]
	HeadLightA = 17280,
	[Description("Head Lights.")]
	HeadLights = 17325,
	[Description("Head Lights C.")]
	HeadLightsC = 17370,
	[Description("Head Lights MG A.")]
	HeadLightsMGA = 17415,
	[Description("Head Lights MG B.")]
	HeadLightsMGB = 17460,
	[Description("Head Lights TT.")]
	HeadLightsTT = 17505,
	[Description("Head Net.")]
	HeadNet = 17550,
	[Description("Hen Egg.")]
	HenEgg = 17595,
	[Description("Hen House.")]
	HenHouse = 17640,
	[Description("Hen Nest.")]
	HenNest = 17685,
	[Description("Hen Roost.")]
	HenRoost = 17730,
	[Description("High Brick.")]
	HighBrick = 17775,
	[Description("High Fix.")]
	HighFix = 17820,
	[Description("High Lark TI.")]
	HighLarkTI = 17865,
	[Description("High Lark 1.")]
	HighLark1 = 17910,
	[Description("High Lark 2.")]
	HighLark2 = 17955,
	[Description("High Lark 4.")]
	HighLark4 = 18000,
	[Description("High Lune.")]
	HighLune = 18045,
	[Description("High Pole A&amp;B.")]
	HighPoleAB = 18090,
	[Description("High Scoop.")]
	HighScoop = 18135,
	[Description("HIGH SCREEN.")]
	HIGHSCREEN = 18150,
	[Description("High Sieve.")]
	HighSieve = 18180,
	[Description("HN-503.")]
	HN503 = 18200,
	[Description("Home Talk.")]
	HomeTalk = 18225,
	[Description("Horn Spoon.")]
	HornSpoon = 18270,
	[Description("HOT BRICK.")]
	HOTBRICK = 18280,
	[Description("Hot Flash.")]
	HotFlash = 18315,
	[Description("Hot Shot TA.")]
	HotShotTA = 18320,
	[Description("Hot Shot TT.")]
	HotShotTT = 18325,
	[Description("Hot Shot MG.")]
	HotShotMG = 18330,
	[Description("IFF MK XII AIMS UPX 29.")]
	IFFMKXIIAIMSUPX29 = 18360,
	[Description("IFF MK XV.")]
	IFFMKXV = 18405,
	[Description("Javelin MG.")]
	JavelinMG = 18410,
	[Description("Jay Bird.")]
	JayBird = 18450,
	[Description("JRC-NMD-401.")]
	const_600 = 18460,
	[Description("Jupiter.")]
	Jupiter = 18495,
	[Description("Jupiter II.")]
	JupiterII = 18540,
	[Description("JY-8.")]
	JY8 = 18550,
	[Description("JY-9.")]
	JY9 = 18555,
	[Description("JY-14.")]
	JY14 = 18560,
	[Description("K376Z.")]
	K376Z = 18585,
	[Description("Kelvin Hughes 2A.")]
	KelvinHughes2A = 18630,
	[Description("Kelvin Hughes 14/9.")]
	KelvinHughes149 = 18675,
	[Description("Kelvin Hughes type 1006.")]
	const_609 = 18720,
	[Description("Kelvin Hughes type 1007.")]
	const_610 = 18765,
	[Description("KH-902M.")]
	KH902M = 18785,
	[Description("Kite Screech.")]
	KiteScreech = 18810,
	[Description("Kite Screech A.")]
	KiteScreechA = 18855,
	[Description("Kite Screech B.")]
	KiteScreechB = 18900,
	[Description("Kivach.")]
	Kivach = 18945,
	[Description("Knife Rest.")]
	KnifeRest = 18990,
	[Description("Knife Rest B.")]
	KnifeRestB = 19035,
	[Description("KNIFE REST C.")]
	KNIFERESTC = 19037,
	[Description("KR-75.")]
	KR75 = 19050,
	[Description("KSA SRN.")]
	KSASRN = 19080,
	[Description("KSA TSR.")]
	KSATSR = 19125,
	[Description("Land Fall.")]
	LandFall = 19170,
	[Description("Land Roll MG.")]
	LandRollMG = 19215,
	[Description("Land Roll TA.")]
	LandRollTA = 19260,
	[Description("Land Roll TT.")]
	LandRollTT = 19305,
	[Description("LC-150.")]
	LC150 = 19310,
	[Description("Leningraf.")]
	Leningraf = 19350,
	[Description("Light Bulb.")]
	LightBulb = 19395,
	[Description("LMT NRAI-6A.")]
	const_629 = 19400,
	[Description("LN 55.")]
	LN55 = 19440,
	[Description("Ln 66.")]
	Ln66 = 19485,
	[Description("Long Bow.")]
	LongBow = 19530,
	[Description("Long Brick.")]
	LongBrick = 19575,
	[Description("Long Bull.")]
	LongBull = 19620,
	[Description("Long Eye.")]
	LongEye = 19665,
	[Description("Long Head.")]
	LongHead = 19710,
	[Description("Long Talk.")]
	LongTalk = 19755,
	[Description("Long Track.")]
	LongTrack = 19800,
	[Description("Long Trough.")]
	LongTrough = 19845,
	[Description("Look Two.")]
	LookTwo = 19890,
	[Description("LORAN.")]
	LORAN = 19935,
	[Description("Low Blow TA.")]
	LowBlowTA = 19950,
	[Description("Low Blow TT.")]
	LowBlowTT = 19955,
	[Description("Low Blow MG.")]
	LowBlowMG = 19960,
	[Description("Low Sieve.")]
	LowSieve = 19980,
	[Description("Low Trough.")]
	LowTrough = 20025,
	[Description("LP-23.")]
	LP23 = 20040,
	[Description("LW 08.")]
	LW08 = 20070,
	[Description("M-1983 FCR.")]
	M1983FCR = 20090,
	[Description("M22-40.")]
	M2240 = 20115,
	[Description("M44.")]
	M44 = 20160,
	[Description("M401Z.")]
	M401Z = 20205,
	[Description("M585Z.")]
	M585Z = 20250,
	[Description("M588Z.")]
	M588Z = 20295,
	[Description("MA 1 IFF Portion.")]
	MA1IFFPortion = 20340,
	[Description("MARELD.")]
	MARELD = 20360,
	[Description("MA Type 909#.")]
	const_657 = 20385,
	[Description("Marconi 1810.")]
	const_658 = 20430,
	[Description("Marconi Canada HC 75.")]
	MarconiCanadaHC75 = 20475,
	[Description("Marconi S 713.")]
	const_660 = 20495,
	[Description("Marconi S 1802.")]
	MarconiS1802 = 20520,
	[Description("Marconi S247.")]
	const_662 = 20530,
	[Description("Marconi S 810.")]
	const_663 = 20565,
	[Description("Marconi SA 10.")]
	const_664 = 20585,
	[Description("Marconi type 967.")]
	MarconiType967 = 20610,
	[Description("Marconi type 968.")]
	MarconiType968 = 20655,
	[Description("Marconi type 992.")]
	MarconiType992 = 20700,
	[Description("Marconi/signaal type 1022.")]
	MarconiSignaalType1022 = 20745,
	[Description("Marconi/signaal type 910.")]
	MarconiSignaalType910 = 20790,
	[Description("Marconi/signaal type 911.")]
	MarconiSignaalType911 = 20835,
	[Description("Marconi/signaal type 992R.")]
	MarconiSignaalType992R = 20880,
	[Description("Mesh Brick.")]
	MeshBrick = 20925,
	[Description("Mirage ILL.")]
	const_673 = 20950,
	[Description("MK 15 CIWS.")]
	MK15CIWS = 20970,
	[Description("MK-23.")]
	MK23 = 21015,
	[Description("MK 23 TAS.")]
	MK23TAS = 21060,
	[Description("MK 25.")]
	MK25 = 21105,
	[Description("MK-35 M2.")]
	MK35M2 = 21150,
	[Description("MK 92.")]
	MK92 = 21195,
	[Description("MK-92 CAS.")]
	MK92CAS = 21240,
	[Description("MK-92 STIR.")]
	MK92STIR = 21285,
	[Description("MK 95.")]
	MK95 = 21330,
	[Description("MLA-1.")]
	MLA1 = 21340,
	[Description("MM APS 705.")]
	MMAPS705 = 21375,
	[Description("MM SPG 74.")]
	MMSPG74 = 21420,
	[Description("MM SPG 75.")]
	MMSPG75 = 21465,
	[Description("MM SPN 703.")]
	MMSPN703 = 21490,
	[Description("MM SPS 702.")]
	MMSPS702 = 21510,
	[Description("MM SPS 768.")]
	MMSPS768 = 21555,
	[Description("MM SPS 774.")]
	MMSPS774 = 21600,
	[Description("Moon 4.")]
	Moon4 = 21645,
	[Description("MMRS.")]
	MMRS = 21650,
	[Description("MPDR 18 X.")]
	MPDR18X = 21690,
	[Description("MT-305X.")]
	MT305X = 21710,
	[Description("Muff Cob.")]
	MuffCob = 21735,
	[Description("Mushroom.")]
	Mushroom = 21780,
	[Description("Mushroom 1.")]
	Mushroom1 = 21825,
	[Description("Mushroom 2.")]
	Mushroom2 = 21870,
	[Description("N920Z.")]
	N920Z = 21880,
	[Description("Nanjing B.")]
	NanjingB = 21890,
	[Description("Nanjing C.")]
	NanjingC = 21895,
	[Description("Nayada.")]
	Nayada = 21915,
	[Description("Neptun.")]
	Neptun = 21960,
	[Description("NIKE TT.")]
	NIKETT = 21980,
	[Description("NRBA 50.")]
	NRBA50 = 22005,
	[Description("NRBA 51.")]
	NRBA51 = 22050,
	[Description("NRBF 20A.")]
	NRBF20A = 22095,
	[Description("Nysa B.")]
	NysaB = 22140,
	[Description("O524A.")]
	O524A = 22185,
	[Description("O580B.")]
	O580B = 22230,
	[Description("O625Z.")]
	O625Z = 22275,
	[Description("O626Z.")]
	O626Z = 22320,
	[Description("Odd Group.")]
	OddGroup = 22345,
	[Description("Odd Lot.")]
	OddLot = 22365,
	[Description("Odd Pair.")]
	OddPair = 22410,
	[Description("Oka.")]
	Oka = 22455,
	[Description("OKEAN.")]
	OKEAN = 22500,
	[Description("OKINXE 12C.")]
	const_718 = 22545,
	[Description("OMEGA.")]
	OMEGA = 22590,
	[Description("Omera ORB32.")]
	const_720 = 22635,
	[Description("One Eye.")]
	OneEye = 22680,
	[Description("OP-28.")]
	OP28 = 22690,
	[Description("OPS-16B.")]
	OPS16B = 22725,
	[Description("OPS-18.")]
	OPS18 = 22730,
	[Description("OPS-28.")]
	OPS28 = 22740,
	[Description("OR-2.")]
	OR2 = 22770,
	[Description("ORB-31S.")]
	ORB31S = 22810,
	[Description("ORB 32.")]
	ORB32 = 22815,
	[Description("Orion Rtn 10X.")]
	const_729 = 22860,
	[Description("Otomat MK II Teseo.")]
	OtomatMKIITeseo = 22905,
	[Description("Owl Screech.")]
	OwlScreech = 22950,
	[Description("P360Z.")]
	P360Z = 22955,
	[Description("PA-1660.")]
	PA1660 = 22960,
	[Description("Palm Frond.")]
	PalmFrond = 22995,
	[Description("Palm Frond AB.")]
	PalmFrondAB = 23040,
	[Description("Pat Hand TT.")]
	PatHandTT = 23085,
	[Description("Pat Hand MG.")]
	PatHandMG = 23095,
	[Description("Patty Cake.")]
	PattyCake = 23130,
	[Description("Pawn Cake.")]
	PawnCake = 23175,
	[Description("PBR 4 Rubin.")]
	const_740 = 23220,
	[Description("Pea Sticks.")]
	PeaSticks = 23265,
	[Description("Peel Cone.")]
	PeelCone = 23310,
	[Description("Peel Group.")]
	PeelGroup = 23355,
	[Description("Peel Group A.")]
	PeelGroupA = 23400,
	[Description("Peel Group B.")]
	PeelGroupB = 23445,
	[Description("Peel Pair.")]
	PeelPair = 23490,
	[Description("Philips 9LV 200.")]
	Philips9LV200 = 23535,
	[Description("Philips 9LV 331.")]
	Philips9LV331 = 23580,
	[Description("Philips LV 223.")]
	PhilipsLV223 = 23625,
	[Description("Philips Sea Giraffe 50 HC.")]
	PhilipsSeaGiraffe50HC = 23670,
	[Description("Pin Jib.")]
	PinJib = 23690,
	[Description("Plank Shad.")]
	PlankShad = 23710,
	[Description("Plank Shave.")]
	PlankShave = 23715,
	[Description("Plank Shave A.")]
	PlankShaveA = 23760,
	[Description("Plank Shave B.")]
	PlankShaveB = 23805,
	[Description("Plate Steer.")]
	PlateSteer = 23850,
	[Description("Plessey AWS 1.")]
	const_757 = 23895,
	[Description("Plessey AWS 4.")]
	const_758 = 23940,
	[Description("Plessey AWS 6.")]
	const_759 = 23985,
	[Description("Plessey RJ.")]
	PlesseyRJ = 23990,
	[Description("Plessey type 996.")]
	PlesseyType996 = 24030,
	[Description("Plinth Net.")]
	PlinthNet = 24075,
	[Description("Pluto.")]
	Pluto = 24095,
	[Description("POHJANPALO.")]
	POHJANPALO = 24100,
	[Description("POLLUX.")]
	POLLUX = 24120,
	[Description("Pop Group.")]
	PopGroup = 24165,
	[Description("Pop Group MG.")]
	PopGroupMG = 24210,
	[Description("Pop Group TA.")]
	PopGroupTA = 24255,
	[Description("Pop Group TT.")]
	PopGroupTT = 24300,
	[Description("Pork Trough.")]
	PorkTrough = 24345,
	[Description("Post Bow.")]
	PostBow = 24390,
	[Description("Post Lamp.")]
	PostLamp = 24435,
	[Description("Pot Drum.")]
	PotDrum = 24480,
	[Description("Pot Head.")]
	PotHead = 24525,
	[Description("PRIMUS 40 WXD.")]
	const_775 = 24570,
	[Description("PRIMUS 300SL.")]
	const_776 = 24615,
	[Description("Primus 3000.")]
	const_777 = 24620,
	[Description("PS-05A.")]
	PS05A = 24650,
	[Description("PS 46 A.")]
	PS46A = 24660,
	[Description("PS 70 R.")]
	PS70R = 24705,
	[Description("PS-890.")]
	PS890 = 24710,
	[Description("Puff Ball.")]
	PuffBall = 24750,
	[Description("R-76.")]
	R76 = 24770,
	[Description("RAC-30.")]
	RAC30 = 24780,
	[Description("Racal 1229.")]
	const_785 = 24795,
	[Description("Racal AC 2690 BT.")]
	RacalAC2690BT = 24840,
	[Description("Racal Decca 1216.")]
	RacalDecca1216 = 24885,
	[Description("Racal Decca 360.")]
	RacalDecca360 = 24930,
	[Description("Racal Decca AC 1290.")]
	RacalDeccaAC1290 = 24975,
	[Description("Racal Decca TM 1229.")]
	RacalDeccaTM1229 = 25020,
	[Description("Racal Decca TM 1626.")]
	RacalDeccaTM1626 = 25065,
	[Description("Racal DRBN 34A.")]
	RacalDRBN34A = 25110,
	[Description("Radar 24.")]
	Radar24 = 25155,
	[Description("RAN 7S.")]
	RAN7S = 25200,
	[Description("RAN 10S.")]
	RAN10S = 25205,
	[Description("RAN 11 LX.")]
	RAN11LX = 25245,
	[Description("Rapier TA.")]
	RapierTA = 25260,
	[Description("Dagger.")]
	Dagger = 25265,
	[Description("Rapier MG.")]
	RapierMG = 25270,
	[Description("RAT-31S.")]
	RAT31S = 25280,
	[Description("RATAC (LCT).")]
	RATACLCT = 25285,
	[Description("Raytheon 1220.")]
	Raytheon1220 = 25290,
	[Description("Raytheon 1302.")]
	Raytheon1302 = 25300,
	[Description("Raytheon 1500.")]
	Raytheon1500 = 25335,
	[Description("Raytheon 1645.")]
	Raytheon1645 = 25380,
	[Description("Raytheon 1650.")]
	Raytheon1650 = 25425,
	[Description("Raytheon 1900.")]
	Raytheon1900 = 25470,
	[Description("Raytheon 2502.")]
	Raytheon2502 = 25515,
	[Description("Raytheon TM 1650/6X.")]
	RaytheonTM16506X = 25560,
	[Description("Raytheon TM 1660/12S.")]
	RaytheonTM166012S = 25605,
	[Description("RAY-1220XR.")]
	const_811 = 25630,
	[Description("RAY-1401.")]
	RAY1401 = 25635,
	[Description("Ray 2900.")]
	Ray2900 = 25650,
	[Description("Raypath.")]
	Raypath = 25695,
	[Description("RBE2.")]
	RBE2 = 25735,
	[Description("RDM.")]
	RDM = 25740,
	[Description("RDY.")]
	RDY = 25760,
	[Description("RDN 72.")]
	RDN72 = 25785,
	[Description("RDR 1A.")]
	RDR1A = 25830,
	[Description("RDR 1E.")]
	RDR1E = 25835,
	[Description("RDR 4A.")]
	RDR4A = 25840,
	[Description("RDR 1200.")]
	RDR1200 = 25875,
	[Description("RDR 1400.")]
	RDR1400 = 25885,
	[Description("RDR 1400 C.")]
	RDR1400C = 25890,
	[Description("RDR 1500.")]
	RDR1500 = 25895,
	[Description("Rice Lamp.")]
	RiceLamp = 25920,
	[Description("Rice Pad.")]
	RicePad = 25965,
	[Description("Rice Screen.")]
	RiceScreen = 26010,
	[Description("ROLAND BN.")]
	ROLANDBN = 26055,
	[Description("ROLAND MG.")]
	ROLANDMG = 26100,
	[Description("ROLAND TA.")]
	ROLANDTA = 26145,
	[Description("ROLAND TT.")]
	ROLANDTT = 26190,
	[Description("Round Ball.")]
	RoundBall = 26235,
	[Description("Round House.")]
	RoundHouse = 26280,
	[Description("Round House B.")]
	RoundHouseB = 26325,
	[Description("RT-02/50.")]
	RT0250 = 26330,
	[Description("RTN-1A.")]
	RTN1A = 26350,
	[Description("RV2.")]
	RV2 = 26370,
	[Description("RV3.")]
	RV3 = 26415,
	[Description("RV5.")]
	RV5 = 26460,
	[Description("RV10.")]
	RV10 = 26505,
	[Description("RV17.")]
	RV17 = 26550,
	[Description("RV18.")]
	RV18 = 26595,
	[Description("RV-377.")]
	RV377 = 26610,
	[Description("RV UM.")]
	RVUM = 26640,
	[Description("RXN 2-60.")]
	RXN260 = 26660,
	[Description("S-1810CD.")]
	S1810CD = 26670,
	[Description("SA 2 Guideline.")]
	SA2Guideline = 26685,
	[Description("SA 3 Goa.")]
	SA3Goa = 26730,
	[Description("SA 8 Gecko DT.")]
	const_850 = 26775,
	[Description("SA-12 TELAR ILL.")]
	SA12TELARILL = 26795,
	[Description("SA N 7 Gadfly TI.")]
	SAN7GadflyTI = 26820,
	[Description("SA N 11 Cads 1 UN.")]
	SAN11Cads1UN = 26865,
	[Description("Salt Pot A&amp;B.")]
	SaltPotAB = 26910,
	[Description("SATURNE II.")]
	SATURNEII = 26955,
	[Description("Scan Can.")]
	ScanCan = 27000,
	[Description("Scan Fix.")]
	ScanFix = 27045,
	[Description("Scan Odd.")]
	ScanOdd = 27090,
	[Description("Scan Three.")]
	ScanThree = 27135,
	[Description("SCANTER (CSR).")]
	SCANTERCSR = 27140,
	[Description("SCORADS.")]
	SCORADS = 27141,
	[Description("SCOREBOARD.")]
	SCOREBOARD = 27150,
	[Description("Scoup Plate.")]
	ScoupPlate = 27180,
	[Description("SCR-584.")]
	SCR584 = 27190,
	[Description("Sea Archer 2.")]
	SeaArcher2 = 27225,
	[Description("Sea Hunter 4 MG.")]
	SeaHunter4MG = 27270,
	[Description("Sea Hunter 4 TA.")]
	SeaHunter4TA = 27315,
	[Description("Sea Hunter 4 TT.")]
	SeaHunter4TT = 27360,
	[Description("Sea Gull.")]
	SeaGull = 27405,
	[Description("Sea Net.")]
	SeaNet = 27450,
	[Description("Sea Spray.")]
	SeaSpray = 27495,
	[Description("Sea Tiger.")]
	SeaTiger = 27540,
	[Description("Searchwater.")]
	Searchwater = 27570,
	[Description("Selenia Orion 7.")]
	SeleniaOrion7 = 27585,
	[Description("Selenia type 912.")]
	SeleniaType912 = 27630,
	[Description("Selennia RAN 12 L/X.")]
	SelenniaRAN12LX = 27675,
	[Description("Selennia RTN 10X.")]
	SelenniaRTN10X = 27720,
	[Description("Selinia ARP 1645.")]
	SeliniaARP1645 = 27765,
	[Description("SGR 102 00.")]
	SGR10200 = 27810,
	[Description("SGR 103/02.")]
	SGR10302 = 27855,
	[Description("SGR-104.")]
	SGR104 = 27870,
	[Description("Sheet Bend.")]
	SheetBend = 27900,
	[Description("Sheet Curve.")]
	SheetCurve = 27945,
	[Description("Ship Globe.")]
	ShipGlobe = 27990,
	[Description("Ship Wheel.")]
	ShipWheel = 28035,
	[Description("SGR 114.")]
	SGR114 = 28080,
	[Description("Shore Walk A.")]
	ShoreWalkA = 28125,
	[Description("Short Horn.")]
	ShortHorn = 28170,
	[Description("Shot Dome.")]
	ShotDome = 28215,
	[Description("Side Globe JN.")]
	SideGlobeJN = 28260,
	[Description("Side Net.")]
	SideNet = 28280,
	[Description("Side Walk A.")]
	SideWalkA = 28305,
	[Description("Signaal DA 02.")]
	const_893 = 28350,
	[Description("Signaal DA 05.")]
	const_894 = 28395,
	[Description("Signaal DA 08.")]
	const_895 = 28440,
	[Description("Signaal LW 08.")]
	const_896 = 28485,
	[Description("Signaal LWOR.")]
	const_897 = 28530,
	[Description("Signaal M45.")]
	const_898 = 28575,
	[Description("Signaal MW 08.")]
	const_899 = 28620,
	[Description("Signaal SMART.")]
	SignaalSMART = 28665,
	[Description("Signaal STING.")]
	SignaalSTING = 28710,
	[Description("Signaal STIR.")]
	const_902 = 28755,
	[Description("Signaal WM 20/2.")]
	SignaalWM202 = 28800,
	[Description("Signaal WM 25.")]
	const_904 = 28845,
	[Description("Signaal WM 27.")]
	const_905 = 28890,
	[Description("Signaal WM 28.")]
	const_906 = 28935,
	[Description("Signaal ZW 01.")]
	const_907 = 28980,
	[Description("Signaal ZW 06.")]
	const_908 = 29025,
	[Description("Ski Pole.")]
	SkiPole = 29070,
	[Description("Skin Head.")]
	SkinHead = 29115,
	[Description("Skip Spin.")]
	SkipSpin = 29160,
	[Description("UAR-1021.")]
	UAR1021 = 29185,
	[Description("UAR-1021.")]
	UAR1021_29190 = 29190,
	[Description("Sky Watch.")]
	SkyWatch = 29205,
	[Description("SKYSHADOW.")]
	SKYSHADOW = 29215,
	[Description("SKYSHIELD TA.")]
	SKYSHIELDTA = 29220,
	[Description("SL.")]
	SL = 29250,
	[Description("SL/ALQ-234.")]
	SLALQ234 = 29270,
	[Description("Slap Shot E.")]
	SlapShotE = 29295,
	[Description("Slim Net.")]
	SlimNet = 29340,
	[Description("Slot Back A.")]
	SlotBackA = 29385,
	[Description("Slot Back ILL.")]
	const_922 = 29400,
	[Description("Slot Back B.")]
	SlotBackB = 29430,
	[Description("Slot Rest.")]
	SlotRest = 29440,
	[Description("SMA 3 RM.")]
	SMA3RM = 29475,
	[Description("SMA 3 RM 20.")]
	SMA3RM20 = 29520,
	[Description("SMA 3RM 20A/SMG.")]
	SMA3RM20ASMG = 29565,
	[Description("SMA BPS 704.")]
	const_928 = 29610,
	[Description("SMA SPIN 749 (V) 2.")]
	SMASPIN749V2 = 29655,
	[Description("SMA SPN 703.")]
	const_930 = 29700,
	[Description("SMA SPN 751.")]
	const_931 = 29745,
	[Description("SMA SPOS 748.")]
	const_932 = 29790,
	[Description("SMA SPQ 2.")]
	SMASPQ2 = 29835,
	[Description("SMA SPQ 2D.")]
	SMASPQ2D = 29880,
	[Description("SMA SPQ 701.")]
	const_935 = 29925,
	[Description("SMA SPS 702 UPX.")]
	SMASPS702UPX = 29970,
	[Description("SMA ST 2 OTOMAT II MH.")]
	SMAST2OTOMATIIMH = 30015,
	[Description("SMA 718 Beacon.")]
	SMA718Beacon = 30060,
	[Description("SNAP SHOT.")]
	SNAPSHOT = 30080,
	[Description("Snoop Drift.")]
	SnoopDrift = 30105,
	[Description("Snoop Head.")]
	SnoopHead = 30150,
	[Description("Snoop Pair.")]
	SnoopPair = 30195,
	[Description("Snoop Plate.")]
	SnoopPlate = 30240,
	[Description("Snoop Slab.")]
	SnoopSlab = 30285,
	[Description("Snoop Tray.")]
	SnoopTray = 30330,
	[Description("Snoop Tray 1.")]
	SnoopTray1 = 30375,
	[Description("Snoop Tray 2.")]
	SnoopTray2 = 30420,
	[Description("Snoop Watch.")]
	SnoopWatch = 30465,
	[Description("Snow Drift.")]
	SnowDrift = 30470,
	[Description("SO-1.")]
	SO1 = 30510,
	[Description("SO-12.")]
	SO12 = 30520,
	[Description("SO A Communist.")]
	SOACommunist = 30555,
	[Description("SO-69.")]
	SO69 = 30580,
	[Description("Sock Eye.")]
	SockEye = 30600,
	[Description("SOM 64.")]
	SOM64 = 30645,
	[Description("SPADA TT.")]
	SPADATT = 30670,
	[Description("Sparrow (AIM/RIM-7) ILL.")]
	SparrowAIMRIM7ILL = 30690,
	[Description("Sperry M-3.")]
	SperryM3 = 30700,
	[Description("SPG 53F.")]
	SPG53F = 30735,
	[Description("SPG 70 (RTN 10X).")]
	const_960 = 30780,
	[Description("SPG 74 (RTN 20X).")]
	const_961 = 30825,
	[Description("SPG 75 (RTN 30X).")]
	const_962 = 30870,
	[Description("SPG 76 (RTN 30X).")]
	const_963 = 30915,
	[Description("Spin Scan A.")]
	SpinScanA = 30960,
	[Description("Spin Scan B.")]
	SpinScanB = 31005,
	[Description("Spin Trough.")]
	SpinTrough = 31050,
	[Description("Splash Drop.")]
	SplashDrop = 31095,
	[Description("SPN 35A.")]
	SPN35A = 31140,
	[Description("SPN 41.")]
	SPN41 = 31185,
	[Description("SPN 42.")]
	SPN42 = 31230,
	[Description("SPN 43A.")]
	SPN43A = 31275,
	[Description("SPN 43B.")]
	SPN43B = 31320,
	[Description("SPN 44.")]
	SPN44 = 31365,
	[Description("SPN 46.")]
	SPN46 = 31410,
	[Description("SPN 703.")]
	SPN703 = 31455,
	[Description("SPN 728 (V) 1.")]
	SPN728V1 = 31500,
	[Description("SPN 748.")]
	SPN748 = 31545,
	[Description("SPN 750.")]
	SPN750 = 31590,
	[Description("Sponge Cake.")]
	SpongeCake = 31635,
	[Description("Spoon Rest.")]
	SpoonRest = 31680,
	[Description("Spoon Rest A.")]
	SpoonRestA = 31681,
	[Description("Spoon Rest B.")]
	SpoonRestB = 31682,
	[Description("Spoon Rest D.")]
	SpoonRestD = 31684,
	[Description("SPQ 712 (RAN 12 L/X).")]
	SPQ712RAN12LX = 31725,
	[Description("SPS 6C.")]
	SPS6C = 31770,
	[Description("SPS 10F.")]
	SPS10F = 31815,
	[Description("SPS 12.")]
	SPS12 = 31860,
	[Description("SPS 768 (RAN EL).")]
	const_988 = 31995,
	[Description("SPS 774 (RAN 10S).")]
	SPS774RAN10S = 32040,
	[Description("SPY 790.")]
	SPY790 = 32085,
	[Description("Square Head.")]
	SquareHead = 32130,
	[Description("Square Pair.")]
	SquarePair = 32175,
	[Description("Square Slot.")]
	SquareSlot = 32220,
	[Description("Square Tie.")]
	SquareTie = 32265,
	[Description("Squash Dome.")]
	SquashDome = 32310,
	[Description("Squat Eye.")]
	SquatEye = 32330,
	[Description("Squint Eye.")]
	SquintEye = 32355,
	[Description("SRN 6.")]
	SRN6 = 32400,
	[Description("SRN 15.")]
	SRN15 = 32445,
	[Description("SRN 745.")]
	SRN745 = 32490,
	[Description("SRO 1.")]
	SRO1 = 32535,
	[Description("SRO 2.")]
	SRO2 = 32580,
	[Description("SS C 2B Samlet MG.")]
	SSC2BSamletMG = 32625,
	[Description("SS N 2A B CSSC.")]
	const_1004 = 32670,
	[Description("SS N 2A B CSSC 2A 3A2 MH.")]
	SSN2ABCSSC2A3A2MH = 32715,
	[Description("SS N 2C Seeker.")]
	const_1006 = 32760,
	[Description("SS N 2C D Styx.")]
	const_1007 = 32805,
	[Description("SS N 2C D Styx C D MH.")]
	SSN2CDStyxCDMH = 32850,
	[Description("SS N 3 SSC SS C 18 BN.")]
	SSN3SSCSSC18BN = 32895,
	[Description("SS N 3B Sepal AL.")]
	SSN3BSepalAL = 32940,
	[Description("SS N 3B Sepal MH.")]
	SSN3BSepalMH = 32985,
	[Description("SS N 9 Siren.")]
	const_1012 = 33030,
	[Description("SS N 9 Siren AL.")]
	const_1013 = 33075,
	[Description("SS N 9 Siren MH.")]
	const_1014 = 33120,
	[Description("SS N 12 Sandbox AL.")]
	SSN12SandboxAL = 33165,
	[Description("SS N 12 Sandbox MH.")]
	SSN12SandboxMH = 33210,
	[Description("SS N 19 Shipwreck.")]
	SSN19Shipwreck = 33255,
	[Description("SS N 19 Shipwreck AL.")]
	SSN19ShipwreckAL = 33300,
	[Description("SS N 19 Shipwreck MH.")]
	SSN19ShipwreckMH = 33345,
	[Description("SS N 21 AL.")]
	SSN21AL = 33390,
	[Description("SS N 22 Sunburn.")]
	SSN22Sunburn = 33435,
	[Description("SS N 22 Sunburn MH.")]
	SSN22SunburnMH = 33480,
	[Description("Stone Cake.")]
	StoneCake = 33525,
	[Description("STR 41.")]
	STR41 = 33570,
	[Description("Straight Flush TA.")]
	StraightFlushTA = 33590,
	[Description("Straight Flush TT.")]
	StraightFlushTT = 33595,
	[Description("Straight Flush ILL.")]
	StraightFlushILL = 33600,
	[Description("Strike Out.")]
	StrikeOut = 33615,
	[Description("Strut Curve.")]
	StrutCurve = 33660,
	[Description("Strut Pair.")]
	StrutPair = 33705,
	[Description("Strut Pair 1.")]
	StrutPair1 = 33750,
	[Description("Strut Pair 2.")]
	StrutPair2 = 33795,
	[Description("Sun Visor.")]
	SunVisor = 33840,
	[Description("Superfledermaus.")]
	Superfledermaus = 33860,
	[Description("Swift Rod 1.")]
	SwiftRod1 = 33885,
	[Description("Swift Rod 2.")]
	SwiftRod2 = 33930,
	[Description("T1166.")]
	T1166 = 33975,
	[Description("T1171.")]
	T1171 = 34020,
	[Description("T1202.")]
	T1202 = 34040,
	[Description("T6004.")]
	T6004 = 34065,
	[Description("T6031.")]
	T6031 = 34110,
	[Description("T8067.")]
	T8067 = 34155,
	[Description("T8068.")]
	T8068 = 34200,
	[Description("T8124.")]
	T8124 = 34245,
	[Description("T8408.")]
	T8408 = 34290,
	[Description("T8911.")]
	T8911 = 34335,
	[Description("T8937.")]
	T8937 = 34380,
	[Description("T8944.")]
	T8944 = 34425,
	[Description("T8987.")]
	T8987 = 34470,
	[Description("Tall King.")]
	TallKing = 34515,
	[Description("Tall Mike.")]
	TallMike = 34560,
	[Description("Tall Path.")]
	TallPath = 34605,
	[Description("Team Work.")]
	TeamWork = 34625,
	[Description("THAAD GBR.")]
	THAADGBR = 34640,
	[Description("THD 225.")]
	THD225 = 34650,
	[Description("Picador.")]
	Picador = 34670,
	[Description("THD 5500.")]
	THD5500 = 34695,
	[Description("Thin Path.")]
	ThinPath = 34740,
	[Description("Thin Skin.")]
	ThinSkin = 34785,
	[Description("Thompson CSF TA-10.")]
	ThompsonCSFTA10 = 34795,
	[Description("Thompson CSF TH D 1040 Neptune.")]
	ThompsonCSFTHD1040Neptune = 34830,
	[Description("Thompson CSF Calypso.")]
	const_1062 = 34875,
	[Description("Thompson CSF CASTOR.")]
	ThompsonCSFCASTOR = 34920,
	[Description("Thompson CSF Castor II.")]
	const_1064 = 34965,
	[Description("Thompson CSF DRBC 32A.")]
	const_1065 = 35010,
	[Description("Thompson CSF DRBJ 11 D/E.")]
	const_1066 = 35055,
	[Description("Thompson CSF DRBV 15A.")]
	const_1067 = 35100,
	[Description("Thompson CSF DRBV 15C.")]
	const_1068 = 35145,
	[Description("Thompson CSF DRBV 22D.")]
	const_1069 = 35190,
	[Description("Thompson CSF DRBV 23B.")]
	const_1070 = 35235,
	[Description("Thompson CSF DRUA 33.")]
	ThompsonCSFDRUA33 = 35280,
	[Description("Thompson CSF Mars DRBV 21A.")]
	ThompsonCSFMarsDRBV21A = 35325,
	[Description("Thompson CSF Sea Tiger.")]
	const_1073 = 35370,
	[Description("Thompson CSF Triton.")]
	ThompsonCSFTriton = 35415,
	[Description("Thompson CSF Vega with DRBC 32E.")]
	ThompsonCSFVegaWithDRBC32E = 35460,
	[Description("TIGER-G.")]
	TIGERG = 35480,
	[Description("TIGER-S.")]
	TIGERS = 35490,
	[Description("Tie Rods.")]
	TieRods = 35505,
	[Description("Tin Shield.")]
	TinShield = 35550,
	[Description("Tin Trap.")]
	TinTrap = 35570,
	[Description("TIRSPONDER.")]
	TIRSPONDER = 35580,
	[Description("Toad Stool 1.")]
	ToadStool1 = 35595,
	[Description("Toad Stool 2.")]
	ToadStool2 = 35640,
	[Description("Toad Stool 3.")]
	ToadStool3 = 35685,
	[Description("Toad Stool 4.")]
	ToadStool4 = 35730,
	[Description("Toad Stool 5.")]
	ToadStool5 = 35775,
	[Description("Tomb Stone.")]
	TombStone = 35800,
	[Description("Top Bow.")]
	TopBow = 35820,
	[Description("Top Dome.")]
	TopDome = 35865,
	[Description("Top Knot.")]
	TopKnot = 35910,
	[Description("Top Mesh.")]
	TopMesh = 35955,
	[Description("Top Pair.")]
	TopPair = 36000,
	[Description("Top Plate.")]
	TopPlate = 36045,
	[Description("Top Sail.")]
	TopSail = 36090,
	[Description("Top Steer.")]
	TopSteer = 36135,
	[Description("Top Trough.")]
	TopTrough = 36180,
	[Description("Scrum Half TA.")]
	ScrumHalfTA = 36220,
	[Description("Tor.")]
	Tor = 36225,
	[Description("Scrum Half MG.")]
	ScrumHalfMG = 36230,
	[Description("Track Dish.")]
	TrackDish = 36270,
	[Description("TORSO M.")]
	TORSOM = 36315,
	[Description("Trap Door.")]
	TrapDoor = 36360,
	[Description("TRISPONDE.")]
	TRISPONDE = 36380,
	[Description("TRS 3033.")]
	TRS3033 = 36405,
	[Description("TRS 3405.")]
	TRS3405 = 36420,
	[Description("TRS 3410.")]
	TRS3410 = 36425,
	[Description("TRS 3415.")]
	TRS3415 = 36430,
	[Description("TRS-N.")]
	TRSN = 36450,
	[Description("TSE 5000.")]
	TSE5000 = 36495,
	[Description("TSR 333.")]
	TSR333 = 36540,
	[Description("Tube Arm.")]
	TubeArm = 36585,
	[Description("Twin Eyes.")]
	TwinEyes = 36630,
	[Description("Twin Pill.")]
	TwinPill = 36675,
	[Description("Twin Scan.")]
	TwinScan = 36720,
	[Description("Twin Scan Ro.")]
	TwinScanRo = 36765,
	[Description("Two Spot.")]
	TwoSpot = 36810,
	[Description("TYPE 262.")]
	TYPE262 = 36855,
	[Description("TYPE 275.")]
	TYPE275 = 36900,
	[Description("TYPE 293.")]
	TYPE293 = 36945,
	[Description("TYPE 343 SUN VISOR B.")]
	TYPE343SUNVISORB = 36990,
	[Description("TYPE 347B.")]
	TYPE347B = 37035,
	[Description("Type-404A(CH).")]
	const_1122 = 37050,
	[Description("Type 756.")]
	Type756 = 37080,
	[Description("TYPE 903.")]
	TYPE903 = 37125,
	[Description("TYPE 909 TI.")]
	const_1125 = 37170,
	[Description("TYPE 909 TT.")]
	const_1126 = 37215,
	[Description("TYPE 910.")]
	TYPE910 = 37260,
	[Description("TYPE-931(CH).")]
	const_1128 = 37265,
	[Description("TYPE 965.")]
	TYPE965 = 37305,
	[Description("TYPE 967.")]
	TYPE967 = 37350,
	[Description("TYPE 968.")]
	TYPE968 = 37395,
	[Description("TYPE 974.")]
	TYPE974 = 37440,
	[Description("TYPE 975.")]
	TYPE975 = 37485,
	[Description("TYPE 978.")]
	TYPE978 = 37530,
	[Description("TYPE 992.")]
	TYPE992 = 37575,
	[Description("TYPE 993.")]
	TYPE993 = 37620,
	[Description("TYPE 994.")]
	TYPE994 = 37665,
	[Description("TYPE 1006(1).")]
	const_1138 = 37710,
	[Description("TYPE 1006(2).")]
	const_1139 = 37755,
	[Description("TYPE 1022.")]
	TYPE1022 = 37800,
	[Description("UK MK 10.")]
	UKMK10 = 37845,
	[Description("UPS-220C.")]
	UPS220C = 37850,
	[Description("UPX 1 10.")]
	UPX110 = 37890,
	[Description("UPX 27.")]
	UPX27 = 37935,
	[Description("URN 20.")]
	URN20 = 37980,
	[Description("URN 25.")]
	URN25 = 38025,
	[Description("VOLEX III/IV.")]
	VOLEXIIIIV = 38045,
	[Description("W8818.")]
	W8818 = 38070,
	[Description("W8838.")]
	W8838 = 38115,
	[Description("W8852.")]
	W8852 = 38120,
	[Description("WAS-74S.")]
	WAS74S = 38160,
	[Description("Wasp Head.")]
	WaspHead = 38205,
	[Description("WATCHDOG.")]
	WATCHDOG = 38210,
	[Description("Watch Guard.")]
	WatchGuard = 38250,
	[Description("Watchman.")]
	Watchman = 38260,
	[Description("Western Electric MK 10.")]
	const_1156 = 38295,
	[Description("Westinghouse ADR-4 LRSR.")]
	const_1157 = 38320,
	[Description("Westinghouse Electric SPG 50.")]
	WestinghouseElectricSPG50 = 38340,
	[Description("Westinghouse Electric W 120.")]
	WestinghouseElectricW120 = 38385,
	[Description("Westinghouse SPS 29C.")]
	const_1160 = 38430,
	[Description("Westinghouse SPS 37.")]
	WestinghouseSPS37 = 38475,
	[Description("Wet Eye.")]
	WetEye = 38520,
	[Description("Wet Eye Mod.")]
	WetEyeMod = 38565,
	[Description("WGU-41/B.")]
	WGU41B = 38570,
	[Description("WGU-44/B.")]
	WGU44B = 38572,
	[Description("Whiff.")]
	Whiff = 38610,
	[Description("Whiff Brick.")]
	WhiffBrick = 38655,
	[Description("Whiff Fire.")]
	WhiffFire = 38700,
	[Description("WHITE HOUSE.")]
	WHITEHOUSE = 38715,
	[Description("Wild Card.")]
	WildCard = 38745,
	[Description("Witch Eight.")]
	WitchEight = 38790,
	[Description("Witch Five.")]
	WitchFive = 38835,
	[Description("WM2X Series.")]
	const_1173 = 38880,
	[Description("WM2X Series CAS.")]
	WM2XSeriesCAS = 38925,
	[Description("WSR-74C.")]
	WSR74C = 38950,
	[Description("WSR-74S.")]
	WSR74S = 38955,
	[Description("Wood Gage.")]
	WoodGage = 38970,
	[Description("Yard Rake.")]
	YardRake = 39015,
	[Description("Yew Loop.")]
	YewLoop = 39060,
	[Description("Yo-Yo.")]
	YoYo = 39105
}
