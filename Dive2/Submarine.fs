module AdventOfCode21.Dive2.Submarine

type Pos = XY of (int * int)

type Aim = int

type Submarine = Submarine of (Pos * Aim)

type Cmd =
    | Move of int
    | ChangeAim of int


let zeroSub = Submarine(XY(0, 0), 0)

let pos (Submarine (pos, _)) = pos

let aim (Submarine (_, aim)) = aim

let withPos pos sub = Submarine(pos, sub |> aim)

let withAim aim sub = Submarine(sub |> pos, aim)

let move (distance: int) sub =
    let (XY (x, y)) = sub |> pos
    let newPos = XY(x + distance, y + (sub |> aim) * distance)
    sub |> withPos newPos

let changeAim distance sub = sub |> withAim ((sub |> aim) + distance)

let executeCmd cmd sub =
    match cmd with
    | Move distance -> sub |> move distance
    | ChangeAim distance -> sub |> changeAim distance

let multipliedPos sub =
    let (XY (x, y)) = sub |> pos
    x * y
