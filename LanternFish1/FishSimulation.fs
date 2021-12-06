module AdventOfCode21.LanternFish1.FishSimulation

type Fish = { DaysToBaby: int }

type Pop = Members of Fish list


let makeFish daysToBaby = { DaysToBaby = daysToBaby }

let makePop = Members

let babyFish = makeFish 8

let members (Members fish) = fish

let fishCount pop = pop |> members |> List.length

let daysToBaby fish = fish.DaysToBaby

let progressFish fish =
    let age = fish |> daysToBaby

    if age = 0 then
        makeFish 6, Some babyFish
    else
        makeFish (age - 1), None

let progressPop pop =

    pop
    |> members
    |> List.map progressFish
    |> List.collect
        (fun (fish, optBaby) ->
            match optBaby with
            | Some baby -> [ fish; baby ]
            | None -> [ fish ])
    |> Members
