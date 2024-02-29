namespace Samokhvalov.LeetCode.Problems.LinkedList;

public class AddTwoNumbers : ILeetCodeProblem
{
    public string ProblemUrl => "https://leetcode.com/problems/add-two-numbers";

    public ProblemLevel Level => ProblemLevel.Medium;

    public void Run()
    {
        throw new NotImplementedException();
    }

    public ListNode AddTwoNumbersImpl1(ListNode l1, ListNode l2) {
        var resultHead = l1;
        var result = resultHead;
        var carry = 0;

        while (l1 != null || l2 != null || carry != 0)
        { 
            var v1 = l1 == null ? 0 : l1.val;
            var v2 = l2 == null ? 0 : l2.val;
            var v = v1 + v2 + carry;

            if (v / 10 == 1)
            {
                resultHead.val = v - 10;
                carry = 1; 
            } else {
                resultHead.val = v;
                carry = 0;
            }

            l1 = l1?.next;
            l2 = l2?.next;
            resultHead.next = l1 ?? l2 ?? (carry == 0 ? null : new ListNode(0));
            resultHead = resultHead.next;
        }

        return result;            
    }
    
    private ListNode AddTwoNumbersR(ListNode l1, ListNode l2, int carry) {
        if (l1 == null && l2 == null && carry == 0) { return null;}

        var v1 = l1?.val ?? 0;
        var v2 = l2?.val ?? 0;
        var newVal = v1 + v2 + carry;

        carry = newVal / 10 == 1 ? 1 : 0; 
        var newNode = new ListNode(carry == 1 ? newVal - 10 : newVal);

        newNode.next = AddTwoNumbersR(l1?.next, l2?.next, carry);

        return newNode;
    }
    
    public bool Solved => false;
}