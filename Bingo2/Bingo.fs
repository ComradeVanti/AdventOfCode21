module AdventOfCode21.Bingo2.Bingo

open AdventOfCode21.Bingo2.Util


type Field = int * bool

type Board = Fields of Field list list

type Game = Boards of Board list


let makeBoard numbers = numbers |> mapNested (addSnd false) |> Fields

let startGame = Boards


let fields (Fields fields) = fields

let unmarkedNumbers board =
    board
    |> fields
    |> List.concat
    |> List.filter (snd >> (=) false)
    |> List.map fst

let boards (Boards boards) = boards


let mark field = fst field, true

let markNumber number board =
    board
    |> fields
    |> List.map (predMap (fst >> (=) number) mark)
    |> Fields

let isWinner board =

    let isWinner sequence = sequence |> List.forall (snd >> (=) true)

    let rows = board |> fields
    let columns = rows |> rotate

    rows |> List.exists isWinner
    || columns |> List.exists isWinner

let winners game = game |> boards |> List.filter isWinner

let tryFindWinner game = game |> winners |> List.tryHead

let score lastMarked board =
    let unmarkedSum = board |> unmarkedNumbers |> List.sum

    unmarkedSum * lastMarked

let progress number game =
    game |> boards |> List.map (markNumber number) |> Boards
