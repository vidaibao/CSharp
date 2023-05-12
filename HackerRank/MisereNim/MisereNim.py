from functools import reduce

def misereNim(s):
    if(max(s) == 1):
        return "First" if len(s)%2 == 0 else "Second"
        
    xor = reduce((lambda x,y:x ^ y), s) 
    return "Second" if xor == 0 else "First"