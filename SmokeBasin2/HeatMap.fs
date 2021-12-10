module AdventOfCode21.SmokeBasin2.HeatMap

open AdventOfCode21
open Microsoft.FSharp.Collections

type Height = int

type HeatMap = Grid<Height>

type Basin = Set<CellPos>

let contains point basin = basin |> Set.contains point

let findLowPoints (heatMap: HeatMap) =

    let isLowPoint (height, pos) =
        heatMap
        |> Grid.getAdjacentTo pos
        |> List.forall (fun otherHeight -> otherHeight > height)

    heatMap |> Grid.filter isLowPoint

let findBasins heatMap : Basin list =

    let isInBasin point =
        heatMap
        |> Grid.tryGet point
        |> Option.exists (fun height -> height < 9)

    let rec floodFill point points =
        if point |> isInBasin && not <| (points |> Set.contains point) then
            points
            |> Set.add point
            |> floodFill (Grid.northOf point)
            |> floodFill (Grid.eastOf point)
            |> floodFill (Grid.southOf point)
            |> floodFill (Grid.westOf point)
        else
            points

    let makeBasinAround lowPoint = floodFill lowPoint Set.empty

    heatMap
    |> findLowPoints
    |> List.map snd
    |> List.map makeBasinAround

let basinSize (basin: Basin) = basin |> Set.count
