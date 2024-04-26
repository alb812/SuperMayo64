//Maya ASCII 2018 scene
//Name: OctagonScales.ma
//Last modified: Tue, Dec 04, 2018 11:04:03 AM
//Codeset: 1252
requires maya "2018";
currentUnit -l centimeter -a degree -t film;
fileInfo "application" "maya";
fileInfo "product" "Maya 2018";
fileInfo "version" "2018";
fileInfo "cutIdentifier" "201706261615-f9658c4cfc";
fileInfo "osv" "Microsoft Windows 8 Home Premium Edition, 64-bit  (Build 9200)\n";
fileInfo "license" "student";
createNode transform -s -n "persp";
	rename -uid "8EF62357-4C61-5D35-5703-38A08B81D976";
	setAttr ".v" no;
	setAttr ".t" -type "double3" -0.82833048399913167 9.5586258964208817 9.3811781766347799 ;
	setAttr ".r" -type "double3" -48.93835272956148 -3.4000000000309076 1.9913517977431096e-16 ;
createNode camera -s -n "perspShape" -p "persp";
	rename -uid "C91A8A46-4B17-620C-AA0E-8F952CC3B3E8";
	setAttr -k off ".v" no;
	setAttr ".fl" 34.999999999999993;
	setAttr ".coi" 11.631629602894566;
	setAttr ".imn" -type "string" "persp";
	setAttr ".den" -type "string" "persp_depth";
	setAttr ".man" -type "string" "persp_mask";
	setAttr ".hc" -type "string" "viewSet -p %camera";
	setAttr ".ai_translator" -type "string" "perspective";
createNode transform -s -n "top";
	rename -uid "B1FEA817-4137-FB52-2476-A8A2978DAD44";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 0 1000.1 0 ;
	setAttr ".r" -type "double3" -89.999999999999986 0 0 ;
createNode camera -s -n "topShape" -p "top";
	rename -uid "2DABD7B1-4F2F-D0EC-F6E9-009851335782";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".coi" 1000.1;
	setAttr ".ow" 30;
	setAttr ".imn" -type "string" "top";
	setAttr ".den" -type "string" "top_depth";
	setAttr ".man" -type "string" "top_mask";
	setAttr ".hc" -type "string" "viewSet -t %camera";
	setAttr ".o" yes;
	setAttr ".ai_translator" -type "string" "orthographic";
createNode transform -s -n "front";
	rename -uid "93EF92BC-4CDD-66F9-DE5E-80B1962D8688";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 0 0 1000.1 ;
createNode camera -s -n "frontShape" -p "front";
	rename -uid "03F01CCA-4978-0D69-AB31-3A8763AF924D";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".coi" 1000.1;
	setAttr ".ow" 30;
	setAttr ".imn" -type "string" "front";
	setAttr ".den" -type "string" "front_depth";
	setAttr ".man" -type "string" "front_mask";
	setAttr ".hc" -type "string" "viewSet -f %camera";
	setAttr ".o" yes;
	setAttr ".ai_translator" -type "string" "orthographic";
createNode transform -s -n "side";
	rename -uid "D2319FA5-4C73-F5C7-8B46-08A13DAE06EC";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 1000.1 0 0 ;
	setAttr ".r" -type "double3" 0 89.999999999999986 0 ;
createNode camera -s -n "sideShape" -p "side";
	rename -uid "502044BA-4DFA-103D-96C7-458266C134DA";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".coi" 1000.1;
	setAttr ".ow" 30;
	setAttr ".imn" -type "string" "side";
	setAttr ".den" -type "string" "side_depth";
	setAttr ".man" -type "string" "side_mask";
	setAttr ".hc" -type "string" "viewSet -s %camera";
	setAttr ".o" yes;
	setAttr ".ai_translator" -type "string" "orthographic";
createNode transform -n "pCube1";
	rename -uid "9CC9DA7B-44F4-EDB6-7CBD-609F056E80B7";
	setAttr ".t" -type "double3" -2.2026393608184094 1.1780847513252914 0.46150870029049829 ;
	setAttr ".s" -type "double3" 1 1 0.75593047671259384 ;
createNode mesh -n "pCubeShape1" -p "pCube1";
	rename -uid "07BB9C80-42F0-B87E-AD10-C6A4FAC0954E";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.5 0.5 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr ".ai_translator" -type "string" "polymesh";
createNode transform -n "pCube2";
	rename -uid "717B33B0-4646-86F8-4C30-C4BA5534935F";
	setAttr ".t" -type "double3" -1.7786723125288599 1.3534652159095601 1.2568136706988624 ;
	setAttr ".s" -type "double3" 0.20904765849822357 1 1 ;
createNode mesh -n "pCubeShape2" -p "pCube2";
	rename -uid "9C761A5E-4E98-7DCC-DF49-D494CF178DA9";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.25 0.125 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 14 ".pt";
	setAttr ".pt[0]" -type "float3" -0.6816873 0 0 ;
	setAttr ".pt[2]" -type "float3" -0.6816873 0 0 ;
	setAttr ".pt[4]" -type "float3" -0.6816873 -0.1672783 0.35677791 ;
	setAttr ".pt[5]" -type "float3" 0 -0.1672783 0.35677791 ;
	setAttr ".pt[6]" -type "float3" -0.6816873 -0.1672783 0.35677791 ;
	setAttr ".pt[7]" -type "float3" 0 -0.1672783 0.35677791 ;
	setAttr ".pt[8]" -type "float3" -0.6816873 0 0 ;
	setAttr ".pt[10]" -type "float3" 0 -0.014288707 0 ;
	setAttr ".pt[11]" -type "float3" -0.6816873 -0.014288766 0 ;
	setAttr ".pt[12]" -type "float3" -0.6816873 0.78658712 -0.37742814 ;
	setAttr ".pt[13]" -type "float3" 0 0.78658712 -0.37742814 ;
	setAttr ".pt[14]" -type "float3" 0 -0.75282609 -0.39438435 ;
	setAttr ".pt[15]" -type "float3" -0.6816873 -0.75282609 -0.39438435 ;
	setAttr ".ai_translator" -type "string" "polymesh";
createNode lightLinker -s -n "lightLinker1";
	rename -uid "2028D6FF-478D-AD5B-BAF4-AF9BF08D7112";
	setAttr -s 2 ".lnk";
	setAttr -s 2 ".slnk";
createNode shapeEditorManager -n "shapeEditorManager";
	rename -uid "A348FF96-457A-CC26-D768-979C0AE9786D";
createNode poseInterpolatorManager -n "poseInterpolatorManager";
	rename -uid "D76C4758-4153-46E0-D95D-108BB79C8E41";
createNode displayLayerManager -n "layerManager";
	rename -uid "C09F93AB-4E67-6BBB-C402-0283BED68A0B";
createNode displayLayer -n "defaultLayer";
	rename -uid "E690D1C4-4C99-5A63-5341-209B707BE9E0";
createNode renderLayerManager -n "renderLayerManager";
	rename -uid "462D9CA4-4C57-A5C0-D9A8-5D802721D766";
createNode renderLayer -n "defaultRenderLayer";
	rename -uid "5CD4CBE4-4CC1-726E-15D0-739AD78536AA";
	setAttr ".g" yes;
createNode polyCube -n "polyCube1";
	rename -uid "B5CB8B44-4F4D-B2B6-A92D-1B92AA388B5B";
	setAttr ".w" 2.0812628356655694;
	setAttr ".h" 2.3561695026505829;
	setAttr ".d" 3.4964486012497176;
	setAttr ".cuv" 4;
createNode polySplitRing -n "polySplitRing1";
	rename -uid "D4FA4F2D-4166-8FFE-6C21-B8A3667F0CE4";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 2 "e[4:5]" "e[8:9]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 0.75593047671259384 0 -2.2026393608184094 1.1780847513252914 0.46150870029049829 1;
	setAttr ".wt" 0.78213357925415039;
	setAttr ".dr" no;
	setAttr ".re" 5;
	setAttr ".sma" 29.999999999999996;
	setAttr ".stp" 0;
	setAttr ".p[0]"  0 0 1;
	setAttr ".uem" no;
	setAttr ".fq" yes;
createNode polySplitRing -n "polySplitRing2";
	rename -uid "8E1CF3D6-4341-19BC-8022-C0924BB9D611";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 3 "e[4:5]" "e[15]" "e[17]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 0.75593047671259384 0 -2.2026393608184094 1.1780847513252914 0.46150870029049829 1;
	setAttr ".wt" 0.36860036849975586;
	setAttr ".re" 5;
	setAttr ".sma" 29.999999999999996;
	setAttr ".stp" 0;
	setAttr ".p[0]"  0 0 1;
	setAttr ".uem" no;
	setAttr ".fq" yes;
createNode polySplitRing -n "polySplitRing3";
	rename -uid "252649FF-48BA-A34E-6134-4684555CB7D7";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 6 "e[6:7]" "e[10:11]" "e[16]" "e[19]" "e[24]" "e[27]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 0.75593047671259384 0 -2.2026393608184094 1.1780847513252914 0.46150870029049829 1;
	setAttr ".wt" 0.22120305895805359;
	setAttr ".re" 7;
	setAttr ".sma" 29.999999999999996;
	setAttr ".stp" 0;
	setAttr ".p[0]"  0 0 1;
	setAttr ".uem" no;
	setAttr ".fq" yes;
createNode polySplitRing -n "polySplitRing4";
	rename -uid "89D7F77A-4235-82D0-7DB9-229109751999";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 5 "e[10:11]" "e[19]" "e[27:29]" "e[31]" "e[33]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 0.75593047671259384 0 -2.2026393608184094 1.1780847513252914 0.46150870029049829 1;
	setAttr ".wt" 0.70670533180236816;
	setAttr ".dr" no;
	setAttr ".re" 28;
	setAttr ".sma" 29.999999999999996;
	setAttr ".stp" 0;
	setAttr ".p[0]"  0 0 1;
	setAttr ".uem" no;
	setAttr ".fq" yes;
createNode polyTweak -n "polyTweak1";
	rename -uid "F9805EA6-4E66-FE75-4594-B5B329A0E158";
	setAttr ".uopa" yes;
	setAttr -s 28 ".tk";
	setAttr ".tk[0]" -type "float3" 1.1417745 0.66881692 -1.3411045e-07 ;
	setAttr ".tk[1]" -type "float3" -1.4901161e-07 0.66881692 -1.3411045e-07 ;
	setAttr ".tk[2]" -type "float3" 1.1417745 -0.5036512 0.46829677 ;
	setAttr ".tk[3]" -type "float3" -1.6391277e-07 -0.5036512 0.46829677 ;
	setAttr ".tk[4]" -type "float3" 1.1417745 -0.51164329 5.9604645e-08 ;
	setAttr ".tk[5]" -type "float3" -1.5646219e-07 -0.51164329 5.9604645e-08 ;
	setAttr ".tk[6]" -type "float3" 1.1417745 0.67632854 5.9604645e-08 ;
	setAttr ".tk[7]" -type "float3" -1.5646219e-07 0.67632854 5.9604645e-08 ;
	setAttr ".tk[8]" -type "float3" -4.4703484e-08 7.4505806e-09 0.52565449 ;
	setAttr ".tk[9]" -type "float3" 1.1417745 7.4505806e-09 0.52565455 ;
	setAttr ".tk[10]" -type "float3" 1.1417745 7.4505806e-09 5.9604645e-08 ;
	setAttr ".tk[11]" -type "float3" 0 7.4505806e-09 5.9604645e-08 ;
	setAttr ".tk[12]" -type "float3" 0 7.4505806e-09 0.52565449 ;
	setAttr ".tk[13]" -type "float3" 1.1417745 7.4505806e-09 0.52565455 ;
	setAttr ".tk[14]" -type "float3" 1.1417745 7.4505806e-09 5.9604645e-08 ;
	setAttr ".tk[15]" -type "float3" 0 7.4505806e-09 5.9604645e-08 ;
	setAttr ".tk[16]" -type "float3" 0 7.4505806e-09 0 ;
	setAttr ".tk[17]" -type "float3" 1.1417745 7.4505806e-09 1.4901161e-08 ;
	setAttr ".tk[18]" -type "float3" 1.1417745 0 1.4901161e-08 ;
	setAttr ".tk[19]" -type "float3" 1.1417745 0 1.4901161e-08 ;
	setAttr ".tk[20]" -type "float3" 1.1417745 7.4505806e-09 1.4901161e-08 ;
	setAttr ".tk[21]" -type "float3" 0 7.4505806e-09 0 ;
	setAttr ".tk[24]" -type "float3" 0 7.4505806e-09 5.9604645e-08 ;
	setAttr ".tk[25]" -type "float3" 1.1417745 7.4505806e-09 5.9604645e-08 ;
	setAttr ".tk[26]" -type "float3" 1.1417745 0 1.4901161e-08 ;
	setAttr ".tk[27]" -type "float3" 1.1417745 0 1.4901161e-08 ;
	setAttr ".tk[28]" -type "float3" 1.1417745 7.4505806e-09 5.9604645e-08 ;
	setAttr ".tk[29]" -type "float3" 0 7.4505806e-09 5.9604645e-08 ;
createNode deleteComponent -n "deleteComponent1";
	rename -uid "B830E12B-4492-FF75-3853-5A9E4E78FF0E";
	setAttr ".dc" -type "componentList" 1 "e[0:59]";
createNode polyCube -n "polyCube2";
	rename -uid "AA7CD3F3-4A87-CF6E-AB71-0380C51D4B76";
	setAttr ".w" 5.0466451958847323;
	setAttr ".h" 2.7069304318191203;
	setAttr ".d" 2.9441053337270855;
	setAttr ".cuv" 4;
createNode polyExtrudeFace -n "polyExtrudeFace1";
	rename -uid "31DFED0D-4A1A-9D22-D7A1-B8867FB9BD7C";
	setAttr ".ics" -type "componentList" 1 "f[0]";
	setAttr ".ix" -type "matrix" 0.20904765849822357 0 0 0 0 1 0 0 0 0 1 0 -1.7786723125288599 1.3534652159095601 1.2568136706988624 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" -1.7786722 1.3534652 2.7288666 ;
	setAttr ".rs" 40633;
	setAttr ".lt" -type "double3" -1.0933781862822287e-15 6.6613381477509392e-16 1.3049206752689519 ;
	setAttr ".ls" -type "double3" 1 1 2.0245018760088693 ;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -2.3061669899828416 1.6439040129156979e-08 2.7288663640658668 ;
	setAttr ".cbx" -type "double3" -1.2511774357114951 2.7069304153800804 2.7288666024844459 ;
createNode polyTweak -n "polyTweak2";
	rename -uid "E487BD82-4FCD-9744-41D7-809F4E0C4A6F";
	setAttr ".uopa" yes;
	setAttr -s 7 ".tk";
	setAttr ".tk[1]" -type "float3" 9.5367432e-07 0 2.3841858e-07 ;
	setAttr ".tk[3]" -type "float3" 9.5367432e-07 0 2.3841858e-07 ;
	setAttr ".tk[4]" -type "float3" -2.9802322e-07 -0.66079772 1.8383604 ;
	setAttr ".tk[5]" -type "float3" 2.9802322e-07 -0.66079772 1.8383604 ;
	setAttr ".tk[6]" -type "float3" 0 0.89537251 1.8383604 ;
	setAttr ".tk[7]" -type "float3" 0 0.89537251 1.8383604 ;
createNode polyExtrudeFace -n "polyExtrudeFace2";
	rename -uid "615628AD-4269-9C69-8172-CFA96BBAD1E6";
	setAttr ".ics" -type "componentList" 1 "f[0]";
	setAttr ".ix" -type "matrix" 0.20904765849822357 0 0 0 0 1 0 0 0 0 1 0 -1.7786723125288599 1.3534652159095601 1.2568136706988624 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" -1.7786726 1.3534652 4.0337877 ;
	setAttr ".rs" 62020;
	setAttr ".lt" -type "double3" -3.1405419409524012e-16 0 1.0286229280759696 ;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -2.3061672890279161 1.6439040129156979e-08 4.0337873950640972 ;
	setAttr ".cbx" -type "double3" -1.2511778344382609 2.7069304153800804 4.0337878719012554 ;
select -ne :time1;
	setAttr ".o" 1;
	setAttr ".unw" 1;
select -ne :hardwareRenderingGlobals;
	setAttr ".otfna" -type "stringArray" 22 "NURBS Curves" "NURBS Surfaces" "Polygons" "Subdiv Surface" "Particles" "Particle Instance" "Fluids" "Strokes" "Image Planes" "UI" "Lights" "Cameras" "Locators" "Joints" "IK Handles" "Deformers" "Motion Trails" "Components" "Hair Systems" "Follicles" "Misc. UI" "Ornaments"  ;
	setAttr ".otfva" -type "Int32Array" 22 0 1 1 1 1 1
		 1 1 1 0 0 0 0 0 0 0 0 0
		 0 0 0 0 ;
	setAttr ".fprt" yes;
select -ne :renderPartition;
	setAttr -s 2 ".st";
select -ne :renderGlobalsList1;
select -ne :defaultShaderList1;
	setAttr -s 4 ".s";
select -ne :postProcessList1;
	setAttr -s 2 ".p";
select -ne :defaultRenderingList1;
select -ne :initialShadingGroup;
	setAttr -s 2 ".dsm";
	setAttr ".ro" yes;
select -ne :initialParticleSE;
	setAttr ".ro" yes;
select -ne :defaultRenderGlobals;
	setAttr ".ren" -type "string" "arnold";
select -ne :defaultResolution;
	setAttr ".pa" 1;
select -ne :hardwareRenderGlobals;
	setAttr ".ctrs" 256;
	setAttr ".btrs" 512;
connectAttr "deleteComponent1.og" "pCubeShape1.i";
connectAttr "polyExtrudeFace2.out" "pCubeShape2.i";
relationship "link" ":lightLinker1" ":initialShadingGroup.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" ":initialParticleSE.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" ":initialShadingGroup.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" ":initialParticleSE.message" ":defaultLightSet.message";
connectAttr "layerManager.dli[0]" "defaultLayer.id";
connectAttr "renderLayerManager.rlmi[0]" "defaultRenderLayer.rlid";
connectAttr "polyCube1.out" "polySplitRing1.ip";
connectAttr "pCubeShape1.wm" "polySplitRing1.mp";
connectAttr "polySplitRing1.out" "polySplitRing2.ip";
connectAttr "pCubeShape1.wm" "polySplitRing2.mp";
connectAttr "polySplitRing2.out" "polySplitRing3.ip";
connectAttr "pCubeShape1.wm" "polySplitRing3.mp";
connectAttr "polySplitRing3.out" "polySplitRing4.ip";
connectAttr "pCubeShape1.wm" "polySplitRing4.mp";
connectAttr "polySplitRing4.out" "polyTweak1.ip";
connectAttr "polyTweak1.out" "deleteComponent1.ig";
connectAttr "polyTweak2.out" "polyExtrudeFace1.ip";
connectAttr "pCubeShape2.wm" "polyExtrudeFace1.mp";
connectAttr "polyCube2.out" "polyTweak2.ip";
connectAttr "polyExtrudeFace1.out" "polyExtrudeFace2.ip";
connectAttr "pCubeShape2.wm" "polyExtrudeFace2.mp";
connectAttr "defaultRenderLayer.msg" ":defaultRenderingList1.r" -na;
connectAttr "pCubeShape1.iog" ":initialShadingGroup.dsm" -na;
connectAttr "pCubeShape2.iog" ":initialShadingGroup.dsm" -na;
// End of OctagonScales.ma
