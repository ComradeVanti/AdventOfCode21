module ComradeVanti.AC21.SonarSweep1.Program

open System
open System.IO
open ComradeVanti.AC21.SonarSweep1

type Input = { ReadingFilePath: string }

type Error =
    | MissingPath
    | FileRead
    | InvalidFile

let private printScreen s =
    Console.Clear()
    printfn "Sonar-sweep 1"
    printfn "%s" s

let private tryProcessInput args =
    printScreen "Parsing args..."

    args
    |> Array.tryItem 0
    |> Option.map (fun path -> { ReadingFilePath = path })
    |> Result.ofOption MissingPath

let private tryReadFile input =
    printScreen "Reading file..."

    fun () -> File.ReadAllLines input.ReadingFilePath |> Array.toList
    |> Result.ofOp (fun _ -> FileRead)

let private tryParseReadings lines =
    printScreen "Parsing file..."

    lines
    |> List.map (fun line -> Option.ofOp (fun () -> int line))
    |> Option.collect
    |> Result.ofOption InvalidFile

let private scanReadings readings = readings |> Scanning.countIncreases

let private printResult =
    function
    | Ok increases ->
        printScreen $"The depth increased %d{increases} times"
        0
    | Error e ->
        match e with
        | MissingPath -> printScreen "Missing file-path"
        | FileRead -> printScreen "Could not read file"
        | InvalidFile -> printScreen "Could not parse file"

        1

[<EntryPoint>]
let main args =
    args
    |> tryProcessInput
    |> Result.bind tryReadFile
    |> Result.bind tryParseReadings
    |> Result.map scanReadings
    |> printResult
