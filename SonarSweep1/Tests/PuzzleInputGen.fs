module ComradeVanti.AC21.SonarSweep1.PuzzleInputGen

open ComradeVanti.AC21.SonarSweep1.Scanning
open FsCheck

let genInitial: Gen<Depth> = Gen.choose (100, 200)

let genNext (prev: Depth) : Gen<Depth> = Gen.choose (prev - 5, prev + 20)

let genInput =

    let rec genUntilDone prev count =
        if count <= 0 then
            Gen.constant []
        else
            gen {
                let! next = genNext prev
                let! remaining = genUntilDone next (count - 1)
                return prev :: remaining
            }

    Gen.sized
    <| (fun s ->
        gen {
            let! i = genInitial
            return! genUntilDone i s
        })

type PuzzleInput = PuzzleInput of Depth list

type ArbPuzzleInput =
    static member Valid = genInput |> Gen.map PuzzleInput |> Arb.fromGen
