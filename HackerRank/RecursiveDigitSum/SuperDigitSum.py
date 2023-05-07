def sumDigits(n):
    while len(n) > 1:
        n = str(sum(list(map(int, [i for i in n]))))
    return n

def superDigit(n, k):
    return sumDigits(sumDigits(n) * k)