module AdventOfCode21.HydrothermalVenture1.VentDanger

open AdventOfCode21.Vector
open AdventOfCode21.Line
open AdventOfCode21

let private calcCorners lines =
    let xs = lines |> List.map x1 |> List.append (lines |> List.map x2)
    let ys = lines |> List.map y1 |> List.append (lines |> List.map y2)

    let minX = xs |> List.min
    let maxX = xs |> List.max
    let minY = ys |> List.min
    let maxY = ys |> List.max

    XY(minX, minY), XY(maxX, maxY)

let private findPointsBetween (XY (x1, y1)) (XY (x2, y2)) =
    seq {
        for x in [ x1 .. x2 ] do
            for y in [ y1 .. y2 ] do
                yield XY(x, y)
    }

let private calcPossiblePoints lines =
    let min, max = lines |> calcCorners
    findPointsBetween min max

let calcDanger lines =

    let countContainingLines point =
        lines |> List.countWhere (containsPoint point)

    let points = lines |> calcPossiblePoints

    points
    |> Seq.map countContainingLines
    |> Seq.toList
    |> List.countWhere (fun c -> c >= 2)
