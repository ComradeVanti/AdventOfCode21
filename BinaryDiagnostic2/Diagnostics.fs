module AdventOfCode21.BinaryDiagnostic2.Diagnostics

open AdventOfCode21.BinaryDiagnostic2
open Util
open DiagnosticReport

let calcOxygenGeneratorRating report =
    report |> findLongestMatch mostCommon |> binToDec

let calcCO2ScrubberRating report =
    report |> findLongestMatch leastCommon |> binToDec

let calcLifeSupportRating report =
    let oxygenGeneratorRating = report |> calcOxygenGeneratorRating
    let CO2ScrubberRating = report |> calcCO2ScrubberRating

    oxygenGeneratorRating * CO2ScrubberRating
