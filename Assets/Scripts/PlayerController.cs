using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	public float speed;
	public Text countText;
	public Text winText;
	private int count;
	private Rigidbody rb;

	void Start(){

		rb = GetComponent<Rigidbody>();
		count = 0;
		SetCountText();
		winText.text = "";
		
	}

    void FixedUpdate()
    {
    	float move_h = Input.GetAxis("Horizontal");
    	float move_v = Input.GetAxis("Vertical");

    	Vector3 movement = new Vector3(move_h,0.0f,move_v);

    	rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
    	if(other.gameObject.CompareTag("PickUp"))
    	{
    		other.gameObject.SetActive(false);
    		count = count + 1;
    		SetCountText();
    	}    	
    }

    void SetCountText()
    {
    	countText.text = "Count: " + count.ToString();
    	if (count >= 11)
    	{
    		winText.text = "You WIN";
    	}
    }
}
