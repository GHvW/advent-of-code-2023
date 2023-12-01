from typing import Tuple, Generator

def frontAndBack(input: str) -> Generator[Tuple[str, str], None, None]:
    return ((input[i], input[len(input) - 1 - i]) 
            for i in range(len(input)))

def calibrate(input: str) -> int:
    first = ""
    last = ""  
    for (nextFirst, nextLast) in frontAndBack(input):
        if (first == "" and nextFirst.isdigit()) and (last == "" and nextLast.isdigit()):
            first = nextFirst
            last = nextLast
        elif (first == "" and nextFirst.isdigit()):
            first = nextFirst
        elif (last == "" and nextLast.isdigit()):
            last = nextLast
        
        if first.isdigit() and last.isdigit():
            return int(first + last)

    return 0

with open("./input/day1.txt") as file:
    print(sum(calibrate(it) for it in file))