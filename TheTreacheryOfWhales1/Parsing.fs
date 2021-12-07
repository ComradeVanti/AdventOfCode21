module AdventOfCode21.TheTreacheryOfWhales1.Parsing

open AdventOfCode21
open AdventOfCode21.Parsing

let tryParseInput entries = entries |> List.map tryParseInt |> Option.collect
