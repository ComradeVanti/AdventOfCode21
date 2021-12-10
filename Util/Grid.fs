namespace AdventOfCode21

open AdventOfCode21.Vector

type Row<'Item> = Cells of 'Item list

type Grid<'Item> = Rows of Row<'Item> list

type CellPos = Vector

[<RequireQualifiedAccess>]
module Grid =

    let private rows (Rows rows) = rows

    let private cellsInRow (Cells cells) = cells

    let height grid = grid |> rows |> List.length

    let width grid = grid |> rows |> List.head |> cellsInRow |> List.length

    let contains (XY (x, y): CellPos) grid =
        x >= 0
        && y >= 0
        && x < (grid |> width)
        && y < (grid |> height)

    let tryMake rows =

        let rowsAreEqualLength =
            rows |> List.map List.length |> List.distinct |> List.length = 1

        if rowsAreEqualLength then
            rows |> List.map Cells |> Rows |> Some
        else
            None

    let tryGet (XY (x, y): CellPos) grid =
        grid
        |> rows
        |> List.tryItem y
        |> Option.map cellsInRow
        |> Option.bind (List.tryItem x)

    let offset dx dy (XY (x, y): CellPos) : CellPos = XY(x + dx, y + dy)

    let northOf = offset 0 1

    let southOf = offset 0 -1

    let eastOf = offset 1 0

    let westOf = offset -1 0

    let getAdjacentPositionsTo pos : CellPos list =
        [ northOf pos; eastOf pos; southOf pos; westOf pos ]

    let getAdjacentTo pos grid =
        pos
        |> getAdjacentPositionsTo
        |> List.choose (fun pos -> grid |> tryGet pos)

    let cells (Rows rows) : (_ * CellPos) list =
        rows
        |> List.mapi
            (fun y (Cells cells) ->
                cells
                |> List.indexed
                |> List.map (fun (x, cell) -> cell, (XY(x, y))))
        |> List.concat

    let filter f grid = grid |> cells |> List.filter f
