module AdventOfCode21.BinaryDiagnostic1.Diagnostics

open DiagnosticReport
open Util


let calcGamma report = report |> columns |> List.map mostCommon |> binToDec

let calcEpsilon report = report |> columns |> List.map leastCommon |> binToDec

let calcPowerConsumption report =
    let gamma = calcGamma report
    let epsilon = calcEpsilon report

    gamma * epsilon
