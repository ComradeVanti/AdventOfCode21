module AdventOfCode21.Line

open AdventOfCode21.Vector

type Line = EndPoints of Vector * Vector


let endPoints (EndPoints (s, e)) = (s, e)

let x1 line =
    let XY (x1, _), XY _ = line |> endPoints
    x1

let y1 line =
    let XY (_, y1), XY _ = line |> endPoints
    y1

let x2 line =
    let XY _, XY (x2, _) = line |> endPoints
    x2

let y2 line =
    let XY _, XY (_, y2) = line |> endPoints
    y2

let dir line =
    let x = (line |> x2) - (line |> x1)
    let y = (line |> y2) - (line |> y1)
    XY(x, y) |> normalize

let isHorizontal line = (line |> y1) = (line |> y2)

let isVertical line = (line |> x1) = (line |> x2)

let diff a b = abs (a - b)

let isBetween a b n = (diff a n) + (diff b n) = (diff a b)

let containsPoint (XY (x, y)) (EndPoints (XY (x1, y1), XY (x2, y2))) =
    (x = x1 && y |> isBetween y1 y2)
    || (y = y1 && x |> isBetween x1 x2)
