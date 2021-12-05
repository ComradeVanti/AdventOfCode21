module AdventOfCode21.Vector

type Vector = XY of int * int

let x (XY (x, _)) = x

let y (XY (_, y)) = y

let length (XY (x, y)) =
    if x = 0 then y else x
    |> abs

let divBy i (XY (x, y)) = XY(x / i, y / i)

let add (XY (x2, y2)) (XY (x1, y1)) = XY(x1 + x2, y1 + y2)

let normalize vector = vector |> divBy (vector |> length)
