module AdventOfCode21.SonarSweep1.Sonar

open AdventOfCode21

let analyze readings =
    readings
    |> List.pairwise
    |> List.countWith (fun (f, n) -> f < n)
