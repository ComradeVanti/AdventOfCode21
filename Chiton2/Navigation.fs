module AdventOfCode21.Chiton2.Navigation

open System
open AdventOfCode21
open AdventOfCode21.Vector
open ComradeVanti.FDijkstra

type Danger = int

type DangerMap = Grid<Danger>

type Node = CellPos * Danger

type Path = Nodes of Node list


let nodes (Nodes nodes) = nodes

let cost path = path |> nodes |> List.skip 1 |> List.map snd |> List.sum

let lastPos path = path |> nodes |> List.last |> fst

let append node path = path |> nodes |> List.appendItem node |> Nodes

let contains pos path = path |> nodes |> List.map fst |> List.contains pos

let path = Nodes

let findBestPathBetween start goal map =

    let positions = map |> Grid.positions |> Seq.map XY |> Seq.toList

    let neighbors pos =
        pos
        |> Grid.adjacent
        |> List.filter (fun p -> map |> Grid.contains p)

    let distanceBetween _ pos =
        map
        |> Grid.tryGet pos
        |> Option.map float32
        |> Option.defaultValue Single.MaxValue

    let makePath positions =
        positions
        |> List.map (fun p -> p, (map |> Grid.tryGet p |> Option.get))
        |> path

    Dijkstra.solve start goal positions neighbors distanceBetween
    |> makePath
