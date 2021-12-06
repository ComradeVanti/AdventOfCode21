module AdventOfCode21.LanternFish1.FishSimulation

open AdventOfCode21

type DaysToBaby = int

type FishCount = uint64

type Pop = CountsByDaysToBaby of Map<DaysToBaby, FishCount>


let noFish = 0UL

let countsByDaysToBaby (CountsByDaysToBaby countsByDaysToBaby) =
    countsByDaysToBaby

let emptyPop =
    Map.empty
    |> Map.add 0 noFish
    |> Map.add 1 noFish
    |> Map.add 2 noFish
    |> Map.add 3 noFish
    |> Map.add 4 noFish
    |> Map.add 5 noFish
    |> Map.add 6 noFish
    |> Map.add 7 noFish
    |> Map.add 8 noFish
    |> CountsByDaysToBaby

let addFish daysToBaby pop =
    pop
    |> countsByDaysToBaby
    |> Map.mapAt daysToBaby (fun i -> i + 1UL)
    |> CountsByDaysToBaby

let progress pop =
    let countsByDaysToBaby = pop |> countsByDaysToBaby

    let getCountFor daysToBaby =
        countsByDaysToBaby
        |> Map.tryFind daysToBaby
        |> Option.defaultValue noFish

    Map.empty
    |> Map.add 0 (getCountFor 1)
    |> Map.add 1 (getCountFor 2)
    |> Map.add 2 (getCountFor 3)
    |> Map.add 3 (getCountFor 4)
    |> Map.add 4 (getCountFor 5)
    |> Map.add 5 (getCountFor 6)
    |> Map.add 6 ((getCountFor 7) + (getCountFor 0))
    |> Map.add 7 (getCountFor 8)
    |> Map.add 8 (getCountFor 0)
    |> CountsByDaysToBaby

let fishCount pop =
    pop
    |> countsByDaysToBaby
    |> Map.toList
    |> List.map snd
    |> List.sum
