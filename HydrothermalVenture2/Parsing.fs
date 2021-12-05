module AdventOfCode21.HydrothermalVenture2.Parsing

open System.Text.RegularExpressions
open AdventOfCode21.Parsing
open AdventOfCode21
open AdventOfCode21.Vector
open AdventOfCode21.Line

let private lineRegex = Regex @"(?'x1'\d+),(?'y1'\d+) -> (?'x2'\d+),(?'y2'\d+)"

let private tryParseLine line =
    let regMatch = lineRegex.Match line

    opt {
        let! x1 = regMatch.Groups.["x1"].Value |> tryParseInt
        let! y1 = regMatch.Groups.["y1"].Value |> tryParseInt
        let! x2 = regMatch.Groups.["x2"].Value |> tryParseInt
        let! y2 = regMatch.Groups.["y2"].Value |> tryParseInt

        return EndPoints(XY(x1, y1), (XY(x2, y2)))
    }

let tryParseInput lines = lines |> List.map tryParseLine |> Option.collect
