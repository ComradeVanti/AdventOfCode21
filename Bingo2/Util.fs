module AdventOfCode21.Bingo2.Util


let mapNested f listOfLists = listOfLists |> List.map (List.map f)

let addSnd snd fst = fst, snd

let mapAt i f list =
    list
    |> List.mapi (fun index item -> if index = i then item |> f else item)

let replaceAt i item list = list |> mapAt i (fun _ -> item)

let predMap pred mapper list =
    list
    |> List.map (fun item -> if item |> pred then item |> mapper else item)

let rotate listOfLists =

    let count = listOfLists |> List.head |> List.length

    let makeColumn i = listOfLists |> List.map (List.item i)

    List.init count makeColumn

let splitAtItem item list =

    let rec splitUntilDone list =
        list
        |> List.tryFindIndex ((=) item)
        |> function
            | Some index ->
                let part = list |> List.take index
                let rest = list |> List.skip (index + 1)

                part :: (rest |> splitUntilDone)
            | None -> [ list ]

    list |> splitUntilDone
