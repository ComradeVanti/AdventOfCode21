module AdventOfCode21.BinaryDiagnostic1.DiagnosticReport

type BinDigit =
    | I
    | O

type BinNum = BinDigit list

type DiagnosticReport = BinNum list


let columns (report: DiagnosticReport) =
    let columnCount = report |> List.head |> List.length

    let getColumn i = report |> List.map (List.item i)

    List.init columnCount getColumn

let countItem item list = list |> List.filter ((=) item) |> List.length

let mostCommon digits =
    let iCount = digits |> countItem I
    let oCount = digits |> countItem O

    if iCount > oCount then I else O

let leastCommon digits =
    let iCount = digits |> countItem I
    let oCount = digits |> countItem O

    if iCount > oCount then O else I

let parseReport lines : DiagnosticReport =

    let parseChar c = if c = '1' then I else O

    let parseLine line = line |> Seq.map parseChar |> Seq.toList

    lines |> List.map parseLine
