module AdventOfCode21.TransparentOrigami2.Paper

open AdventOfCode21
open AdventOfCode21.Vector

type Dot = Vector

type Paper = Dots of Dot list

type Axis =
    | Horizontal
    | Vertical

type Dist = int

type Fold = Axis * Dist


let makePaper = Dots

let dots (Dots dots) = dots

let foldUp dist paper =

    let isBelowLine dot = (dot |> y) > dist

    let foldDot dot = dot |> mapY (fun y -> dist - (y - dist))

    paper
    |> dots
    |> List.filterMap isBelowLine foldDot
    |> List.distinct
    |> Dots

let foldLeft dist paper =

    let isRightOfLine dot = (dot |> x) > dist

    let foldDot dot = dot |> mapX (fun x -> dist - (x - dist))

    paper
    |> dots
    |> List.filterMap isRightOfLine foldDot
    |> List.distinct
    |> Dots

let foldPaper fold paper =
    match fold with
    | Horizontal, dist -> paper |> foldUp dist
    | Vertical, dist -> paper |> foldLeft dist

let hasDotAt pos paper = paper |> dots |> List.contains pos

let toString paper =
    let dots = paper |> dots
    let maxX = dots |> List.map x |> List.max
    let maxY = dots |> List.map y |> List.max

    seq {
        yield '\n'

        for y in [ 0 .. maxY ] do
            for x in [ 0 .. maxX ] do
                yield if paper |> hasDotAt (XY(x, y)) then '#' else ' '

            yield '\n'
    }
    |> System.String.Concat
