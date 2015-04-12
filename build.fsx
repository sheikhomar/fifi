// Source: http://www.hanselman.com/blog/ExploringFAKEAnFBuildSystemForAllOfNET.aspx
// include Fake lib
#r "packages/FAKE/tools/FakeLib.dll"
open Fake
 
RestorePackages()
 
// Properties
let buildDir = "./build/"
let testDir  = "./test/"
let deployDir = "./deploy/"
let version = "0.1"  // or retrieve from CI server
 
// Targets
Target "Clean" (fun _ ->
    CleanDirs [buildDir; testDir; deployDir]
)
 
Target "BuildApp" (fun _ ->
   !! "src/app/**/*.csproj"
     |> MSBuildRelease buildDir "Build"
     |> Log "AppBuild-Output: "
)
 
Target "BuildTest" (fun _ ->
    !! "src/test/**/*.csproj"
      |> MSBuildDebug testDir "Build"
      |> Log "TestBuild-Output: "
)
 
Target "Test" (fun _ ->
    !! (testDir + "/fifi.Tests.dll") 
      |> NUnit (fun p ->
          {p with
             DisableShadowCopy = true;
             OutputFile = testDir + "TestResults.xml" })
)
 
Target "Zip" (fun _ ->
    !! (buildDir + "/**/*.*") 
        -- "*.zip"
        |> Zip buildDir (deployDir + "fifi." + version + ".zip")
)
 
Target "Default" (fun _ ->
    trace "Default target. Nothing here."
)
 
// Dependencies
"Clean"
  ==> "BuildApp"
  ==> "BuildTest"
  ==> "Test"
  ==> "Zip"
  ==> "Default"
 
// start build
RunTargetOrDefault "Default"