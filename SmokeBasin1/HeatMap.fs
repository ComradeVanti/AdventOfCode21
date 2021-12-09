module AdventOfCode21.SmokeBasin1.HeatMap

open AdventOfCode21

type Height = int

type HeatMap = Grid<Height>


let findLowPoints (heatMap: HeatMap) =

    let isLowPoint (height, pos) =
        heatMap
        |> Grid.getAdjacentTo pos
        |> List.forall (fun otherHeight -> otherHeight > height)

    heatMap |> Grid.filter isLowPoint

let calculateRiskLevel heatMap =
    heatMap
    |> findLowPoints
    |> List.map fst
    |> List.map ((+) 1)
    |> List.sum
