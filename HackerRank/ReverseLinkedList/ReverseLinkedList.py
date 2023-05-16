def reverse(llist):
    '''
    We take a linked list and from the end, 
    reverse the order adding the items to the start.
    '''
    
    prev = None
    current = llist
    
    # Look through the linked list until you reach the end
    while current:
        # Temp storage of the next pointer
        temp = current.next
        # Setting the next as the previous
        current.next = prev
        # Setting the previous llist as the current
        prev = current
        # Set the current to the temp storage for next
        current = temp
    
    # After reversal, prev is the new linked list
    return prev


def reverse(llist):
    prev = None
    current = llist

    while current:
        next = current.next
        current.next = prev
        prev = current
        current = next
    llist = prev

    return llist