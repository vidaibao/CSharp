def nextPrime(primes):
    np = primes[-1]+1
    found=0
    while not found:
        found=1
        for p in primes:
            if np%p==0:
                np+=1
                found=0
                break
    return np    

def waiter(number, q):
    stackB=[]
    ans=[]
    primes=[2]
    for i in range(q):
        stackA = []
        while number:
            if number[-1]%primes[-1]==0:
                stackB.append(number.pop(-1))
            else:
                stackA.append(number.pop(-1))
        while stackB:
            ans.append(stackB.pop(-1))
        number = stackA
        primes.append(nextPrime(primes))
    
    while stackA:
        ans.append(stackA.pop(-1))
        
    return ans