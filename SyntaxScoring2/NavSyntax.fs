module AdventOfCode21.SyntaxScoring1.NavSyntax

open AdventOfCode21.SyntaxScoring1.Nav
open AdventOfCode21


type SyntaxError = InvalidClose of ChunkType

let check (Dels dels) =

    let rec tryAddDelimiter dels stack =
        match dels with
        | [] -> Ok()
        | next :: remaining ->
            let delType = next |> delType

            match next |> delDir with
            | Open -> stack |> Stack.push delType |> tryAddDelimiter remaining
            | Close ->
                if stack |> Stack.tryPeek |> Option.exists ((=) delType) then
                    stack |> Stack.pop |> tryAddDelimiter remaining
                else
                    Error(InvalidClose delType)

    tryAddDelimiter dels Stack.empty

let isValid line = line |> check |> Result.isOk

let genCompletion (Dels dels) =
    let rec buildCompletion dels stack =
        match dels with
        | [] -> []
        | next :: remaining ->
            let delType = next |> delType

            match next |> delDir with
            | Close -> stack |> Stack.push delType |> buildCompletion remaining
            | Open ->
                let remainingTypes =
                    stack |> Stack.pop |> buildCompletion remaining

                let opensLastClosed =
                    stack |> Stack.tryPeek |> Option.exists ((=) delType)

                if opensLastClosed then
                    remainingTypes
                else
                    delType :: remainingTypes


    buildCompletion (dels |> List.rev) Stack.empty
    |> Stack.toList
