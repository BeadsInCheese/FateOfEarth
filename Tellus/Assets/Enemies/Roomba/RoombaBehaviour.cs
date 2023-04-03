using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoombaBehaviour : MonoBehaviour
{

    BTTree root;
    bool alive = true;
    public HPSystem HP;
    // Start is called before the first frame update
    public Vector3 target = new Vector3();
    public Sprite sad;
    public Sprite happy;
    public GameObject player;
    public Sprite mad;
    public Image image;
    float treshold = 0.2f;
    Rigidbody rb;
    public BTTree.Status selectRandomTarget() {
        image.sprite = happy;
        target = transform.position +new Vector3(Random.Range(-3,3), 0, Random.Range(-3, 3));
        return Node.Status.SUCCESS;
    }
    public BTTree.Status LowHealth()
    {
        if (HP.getHP()/HP.maxHp>0.5)
        {
            return Node.Status.FAILURE;
        }
        else { return Node.Status.SUCCESS; }
    }

    public BTTree.Status moveToTarget()
    {
        if ((this.transform.position - target).magnitude < treshold)
        {
            return Node.Status.SUCCESS;
        }
        else
        {
            rb.velocity =  (target- this.transform.position).normalized;
            return Node.Status.RUNNING;

        }
    }
        void Start()
    {
        rb = GetComponent<Rigidbody>();
        root = new BTTree();
        SelectorNode mode = new SelectorNode("mode");
        SequenceNode LowHealth = new SequenceNode("LowHealth");
        SequenceNode Seek = new SequenceNode("Player Close");
        SequenceNode Wonder = new SequenceNode("Wonder");
        LeafNode selecrandom=new LeafNode("wonder",selectRandomTarget);
        LeafNode movToTarget = new LeafNode("",moveToTarget);

        root.AddChild(mode);
        mode.AddChild(Wonder);
        Wonder.AddChild(selecrandom);
        Wonder.AddChild(movToTarget);
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag.Equals("Player"))
        {
            collision.collider.gameObject.GetComponent<HPSystem>().takeDamage(20);
        }
        Debug.Log(collision.collider.tag);
        if (collision.collider.gameObject.tag.Equals("Bullet"))
        {
            if (!HP.takeDamage(50))
            {
                //Destroy(gameObject);
                alive = false;
                Debug.Log("Dead");
                image.sprite = sad;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.y > 10)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y,0);
        }
        if (alive)
        {

            root.Process();
            transform.LookAt(new Vector3(rb.velocity.x, transform.position.y,rb.velocity.z));
        }
    }
}
