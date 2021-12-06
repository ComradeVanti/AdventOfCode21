module AdventOfCode21.LanternFish1.Parsing

open AdventOfCode21
open AdventOfCode21.Parsing
open AdventOfCode21.LanternFish1.FishSimulation

let tryParseInput entries =
    entries
    |> List.map tryParseInt
    |> List.map (Option.map makeFish)
    |> Option.collect
    |> Option.map makePop
