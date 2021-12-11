module AdventOfCode21.SonarSweep1.Sonar

open AdventOfCode21

let analyze readings =
    readings
    |> List.pairwise
    |> List.countWhere (fun (f, n) -> f < n)
