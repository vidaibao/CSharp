def formingMagicSquare(s):
    possibleSquares = [  
        [[8, 1, 6], [3,5,7], [4,9,2]],
        [[6, 1, 8], [7,5,3], [2,9,4]],    
        [[8, 3, 4], [1,5,9], [6,7,2]],
        [[6, 7, 2], [1,5,9], [8,3,4]],
        [[4, 3, 8], [9,5,1], [2,7,6]],
        [[2, 7, 6], [9,5,1], [4,3,8]],
        [[4, 9, 2], [3,5,7], [8,1,6]],
        [[2, 9, 4], [7,5,3], [6,1,8]],   
    ]
    min_cost=[]
    for arr in possibleSquares:
        cost=0
        i=0
        while i<3:
            j=0
            while j<3:
                print(arr[i][j])
                cost+= abs(s[i][j]-arr[i][j])
                j+=1
            i+=1
        min_cost.append(cost)
    return min(min_cost)