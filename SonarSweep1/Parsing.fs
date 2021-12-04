module AdventOfCode21.SonarSweep1.Parsing

open AdventOfCode21.Parsing
open AdventOfCode21

let tryParseInput lines = lines |> List.map tryParseInt |> Option.collect
