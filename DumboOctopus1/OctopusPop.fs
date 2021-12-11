module AdventOfCode21.DumboOctopus1.OctopusPop

open AdventOfCode21
open AdventOfCode21.DumboOctopus1.Octopus

let private incAll pop = pop |> Grid.map buildEnergy

let private tryBuildEnergy octopus =
    if octopus |> energyLevel = 0 then
        octopus
    else
        octopus |> buildEnergy

let private flashPos pop pos =
    pop
    |> Grid.mapAt pos flash
    |> Grid.mapAt (Grid.northOf pos) tryBuildEnergy
    |> Grid.mapAt (Grid.northEastOf pos) tryBuildEnergy
    |> Grid.mapAt (Grid.eastOf pos) tryBuildEnergy
    |> Grid.mapAt (Grid.southEastOf pos) tryBuildEnergy
    |> Grid.mapAt (Grid.southOf pos) tryBuildEnergy
    |> Grid.mapAt (Grid.southWestOf pos) tryBuildEnergy
    |> Grid.mapAt (Grid.westOf pos) tryBuildEnergy
    |> Grid.mapAt (Grid.northWestOf pos) tryBuildEnergy

let rec private processFlashing pop =
    pop
    |> Grid.filter (fst >> willFlash)
    |> List.map snd
    |> function
        | [] -> pop
        | flashPositions ->
            flashPositions |> List.fold flashPos pop |> processFlashing

let progress pop = pop |> incAll |> processFlashing

let countFlashesInPrevStep pop = pop |> Grid.countWhere (fst >> hasFlashed)
