module AdventOfCode21.SmokeBasin1.Parsing

open AdventOfCode21
open AdventOfCode21.Parsing
open AdventOfCode21.SmokeBasin1.HeatMap


let tryParseInput lines : HeatMap option =
    lines
    |> List.map (
        Seq.map (string >> tryParseInt)
        >> Seq.toList
        >> Option.collect
    )
    |> Option.collect
    |> Option.bind Grid.tryMake
