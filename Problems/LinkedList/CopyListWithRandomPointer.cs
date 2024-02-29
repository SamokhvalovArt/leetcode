namespace Samokhvalov.LeetCode.Problems.LinkedList;

public class CopyListWithRandomPointer : ILeetCodeProblem
{
    public string ProblemUrl => "https://leetcode.com/problems/copy-list-with-random-pointer";

    public ProblemLevel Level => ProblemLevel.Medium;
    
    public void Run()
    {
        throw new NotImplementedException();
    }

    public ListNode CopyRandomList(ListNode head) {
        if (head == null) { return null;}

        var dictOld = new Dictionary<ListNode, int>();
        var dictNew = new Dictionary<int, ListNode>();
        var newHead = new ListNode(head.val);


        dictOld.Add(head, 1);
        dictNew.Add(1, newHead);
        // copy without random link
        var tmpNewHead = newHead;
        var tmpHead = head.next;
        var i = 2;
        while (tmpHead != null) {
            var newNode = new ListNode(tmpHead.val);

            dictOld.Add(tmpHead, i);
            dictNew.Add(i, newNode);

            tmpNewHead.next = newNode;
            tmpNewHead = tmpNewHead.next;
            tmpHead = tmpHead.next;
            i +=1;
        }

        // link randoms
        tmpNewHead = newHead;
        while (head != null)
        {
            if (head.random != null) 
            {
                var position = dictOld[head.random];
                tmpNewHead.random = dictNew[position]; 
            }

            head = head.next;
            tmpNewHead = tmpNewHead.next;
        }

        return newHead;
    }

    public ListNode CopyRandomListImpl2(ListNode head)
    {
        Dictionary<ListNode, ListNode> dict = new Dictionary<ListNode, ListNode>();    
        
        return Copy(head);
        
        ListNode Copy(ListNode node)
        {
            if (node == null) { return null; }

            if (dict.TryGetValue(node, out var randomNode))
            {
                return randomNode;
            }

            var newNode = new ListNode(node.val);    
            dict.Add(node, newNode);

            newNode.next = Copy(node.next);
            newNode.random = Copy(node.random);

            return newNode;
        }
    }
    
    
    public bool Solved => true;
}