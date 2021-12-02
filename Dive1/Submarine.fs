module AdventOfCode21.Dive1.Submarine

type Coord = int

type Submarine = Pos of Coord * Coord

type Direction =
    | Forward
    | Up
    | Down

type Distance = int

type Command = Move of Direction * Distance

let initialSub = Pos(0, 0)

let moveBy (dx: Distance) (dy: Distance) (Pos (x, y)) = Pos(x + dx, y + dy)

let move direction distance sub =
    match direction with
    | Forward -> sub |> moveBy distance 0
    | Down -> sub |> moveBy 0 distance
    | Up -> sub |> moveBy 0 -distance

let executeCommand command sub =
    match command with
    | Move (direction, distance) -> sub |> move direction distance

let multPos (Pos (x, y)) : int = x * y
