namespace ComradeVanti.AC21.SonarSweep1

open ComradeVanti.AC21.SonarSweep1.PuzzleInputGen
open ComradeVanti.AC21.SonarSweep1.Scanning
open FsCheck.Xunit
open Xunit

[<Properties(Arbitrary = [| typeof<ArbPuzzleInput> |])>]
module ScanningTests =

    [<Property>]
    let ``The depth must increase between 0 and n - 1 times``
        (PuzzleInput depthReadings)
        =
        let increases = countIncreases depthReadings
        increases >= 0 && increases < (depthReadings |> List.length)

    [<Property>]
    let ``Analyzing all readings is the same as analyzing pairs and summing``
        (PuzzleInput depthReadings)
        =
        depthReadings
        |> List.pairwise
        |> List.map (List.ofTuple >> countIncreases)
        |> List.sum
        |> (=) (depthReadings |> countIncreases)

    [<Property>]
    let ``A pair is an increase, if the second number is larger than the first``
        pair
        =
        pair
        |> List.ofTuple
        |> countIncreases
        |> (=) (if (pair |> fst) < (pair |> snd) then 1 else 0)

    [<Fact>]
    let ``Example input results in correct output`` () =
        [ 199; 200; 208; 210; 200; 207; 240; 269; 260; 263 ]
        |> countIncreases = 7
        |> Assert.True
