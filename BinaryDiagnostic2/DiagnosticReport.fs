module AdventOfCode21.BinaryDiagnostic2.DiagnosticReport

open AdventOfCode21.BinaryDiagnostic2
open Util


type DiagnosticReport = BinNum list

let mostCommon digits =
    let iCount = digits |> countItem I
    let oCount = digits |> countItem O

    if iCount > oCount then I
    elif iCount = oCount then I
    else O

let leastCommon digits =
    let iCount = digits |> countItem I
    let oCount = digits |> countItem O

    if iCount > oCount then O
    elif iCount = oCount then O
    else I

let parseReport lines : DiagnosticReport =

    let parseChar c = if c = '1' then I else O

    let parseLine line = line |> Seq.map parseChar |> Seq.toList

    lines |> List.map parseLine
