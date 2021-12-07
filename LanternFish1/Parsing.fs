module AdventOfCode21.LanternFish1.Parsing

open AdventOfCode21
open AdventOfCode21.Parsing
open AdventOfCode21.LanternFish1.FishSimulation

let tryParseInput entries =

    let makePop daysToBabies =

        let addToPop pop daysToBaby = pop |> addFish daysToBaby

        daysToBabies |> List.fold addToPop emptyPop


    entries
    |> List.map tryParseInt
    |> Option.collect
    |> Option.map makePop
