## What this does

Takes in a logical expression (in reverse-polish zeros-and-ones notation) and  
returns the value of that expression (zero or one)

```
0: false
1: true
A: and
R: or
X: xor
N: negation

Here's an example:
0 0 A 0 N 0 N A R

0 and 0 = 0
not 0 = 1
not 0 = 1
1 and 1 = 1
0 or 1 = 1

Therefore, the answer is 1
```

## How To Use

```
mcs BooleanSim.cs
mono BooleanSim.exe
*INPUT*
```

## Need Help?

```
mono BooleanSim.exe
help
```
