open System
open System.IO

let calibrate (input: string) : int =
    let reducer (currentFirst, currentLast) (first, last) =
        if currentFirst = ' ' && Char.IsDigit(first) && currentLast = ' ' && Char.IsDigit(last) then
            (first, last)
        else if currentFirst = ' ' && Char.IsDigit(first) then
            (first, currentLast)
        else if currentLast = ' ' && Char.IsDigit(last)  then
            (currentFirst, last)
        else
            (currentFirst, currentLast)

    let (first, last) = 
        seq { for i in 0 .. (input.Length - 1) -> (input[i], input[input.Length - 1 - i]) }
        |> Seq.scan reducer (' ', ' ')
        |> Seq.find (fun (first, last) -> first <> ' ' && last <> ' ')

    Convert.ToInt32(first.ToString() + last.ToString())
    

File.ReadAllLines("./input/day1.txt")
|> Seq.map calibrate
|> Seq.sum
|> printfn "%A"
