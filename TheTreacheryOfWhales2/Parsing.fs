module AdventOfCode21.TheTreacheryOfWhales2.Parsing

open AdventOfCode21
open AdventOfCode21.Parsing

let tryParseInput entries =
    entries
    |> List.map (tryParseInt >> Option.map int64)
    |> Option.collect
